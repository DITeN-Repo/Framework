﻿/*
 * This file is part of Ext JS 4
 * 
 * Copyright (c) 2011 Sencha Inc
 * 
 * Contact:  http://www.sencha.com/contact
 * 
 * GNU General Public License Usage
 * This file may be used under the terms of the GNU General Public License version 3.0 as published by the Free Software Foundation and appearing in the file LICENSE included in the packaging of this file.  Please review the following information to ensure the GNU General Public License version 3.0 requirements will be met: http://www.gnu.org/copyleft/gpl.html.
 * 
 * If you are unsure which license is appropriate for your use, please contact the sales department at http://www.sencha.com/contact.
 * 
 * 
 */


Ext.define("Ext.ux.grid.menu.ListMenu",
	{
		extend: "Ext.menu.Menu",
		idField: "id",
		labelField: "text",
		loadingText: "Loading...",
		loadOnShow: true,
		single: false,
		plain: true,
		constructor: function(cfg) {
			const me = this;
			var options, i, len, value;
			me.selected = [];
			me.addEvents("checkchange");
			me.callParent([cfg = cfg || {}]);
			if (!cfg.store && cfg.options) {
				options = [];
				for (i = 0, len = cfg.options.length; i < len; i++) {
					value = cfg.options[i];
					switch (Ext.type(value)) {
					case"array":
						options.push(value);
						break;
					case"object":
						options.push([value[me.idField], value[me.labelField]]);
						break;
					case"string":
						options.push([value, value]);
						break;
					}
				}
				me.store = Ext.create("Ext.data.ArrayStore",
					{ fields: [me.idField, me.labelField], data: options, listeners: { load: me.onLoad, scope: me } });
				me.loaded = true;
				me.autoStore = true;
			} else {
				if (this.store.getCount() > 0) {
					this.onLoad(this.store, this.store.getRange());
				} else {
					this.add({ text: this.loadingText, iconCls: "loading-indicator" });
					this.store.on("load", this.onLoad, this);
				}
			}
		},
		destroy: function() {
			const me = this;
			const store = me.store;
			if (store) {
				if (me.autoStore) {
					store.destroyStore();
				} else {
					store.un("unload", me.onLoad, me);
				}
			}
			me.callParent();
		},
		show: function() {
			const me = this;
			if (me.loadOnShow && !me.loaded && !me.store.loading) {
				me.store.load();
			}
			me.callParent();
		},
		onLoad: function(store, records) {
			const me = this;
			var gid, itemValue, i, len;
			const listeners = { checkchange: me.checkChange, scope: me };
			Ext.suspendLayouts();
			me.removeAll(true);
			gid = me.single ? Ext.id() : null;
			for (i = 0, len = records.length; i < len; i++) {
				itemValue = records[i].get(me.idField);
				me.add(Ext.create("Ext.menu.CheckItem",
					{
						text: records[i].get(me.labelField),
						group: gid,
						checked: Ext.Array.contains(me.selected, itemValue),
						hideOnClick: false,
						value: itemValue,
						listeners: listeners
					}));
			}
			me.loaded = true;
			Ext.resumeLayouts(true);
			me.fireEvent("load", me, records);
		},
		getSelected: function() { return this.selected; },
		setSelected: function(value) {
			value = this.selected = [].concat(value);
			if (this.loaded) {
				this.items.each(function(item) {
						item.setChecked(false, true);
						for (var i = 0, len = value.length; i < len; i++) {
							if (item.value == value[i]) {
								item.setChecked(true, true);
							}
						}
					},
					this);
			} else {
				this.on("load", Ext.Function.bind(this.setSelected, this, [value]), this, { single: true });
			}
		},
		checkChange: function(item, checked) {
			var value = [];
			this.items.each(function(item) {
					if (item.checked) {
						value.push(item.value);
					}
				},
				this);
			this.selected = value;
			this.fireEvent("checkchange", item, checked);
		}
	});

Ext.define("Ext.ux.grid.menu.RangeMenu",
	{
		extend: "Ext.menu.Menu",
		fieldCls: "Ext.form.field.Number",
		itemIconCls: { gt: "ux-rangemenu-gt", lt: "ux-rangemenu-lt", eq: "ux-rangemenu-eq" },
		fieldLabels: { gt: "Greater Than", lt: "Less Than", eq: "Equal To" },
		menuItemCfgs: { emptyText: "Enter Number...", selectOnFocus: false, width: 155 },
		menuItems: ["lt", "gt", "-", "eq"],
		plain: true,
		constructor: function(config) {
			const me = this;
			var fields, fieldCfg, i, len, item, cfg, Cls;
			me.callParent(arguments);
			fields = me.fields = me.fields || {};
			fieldCfg = me.fieldCfg = me.fieldCfg || {};
			me.addEvents("update");
			me.updateTask = Ext.create("Ext.util.DelayedTask", me.fireUpdate, me);
			for (i = 0, len = me.menuItems.length; i < len; i++) {
				item = me.menuItems[i];
				if (item !== "-") {
					cfg = {
						itemId: `range-${item}`,
						enableKeyEvents: true,
						hideEmptyLabel: false,
						labelCls: `ux-rangemenu-icon ${me.itemIconCls[item]}`,
						labelSeparator: "",
						labelWidth: 29,
						listeners: {
							scope: me,
							change: me.onInputChange,
							keyup: me.onInputKeyUp,
							el: { click: this.stopFn }
						},
						activate: Ext.emptyFn,
						deactivate: Ext.emptyFn
					};
					Ext.apply(cfg, Ext.applyIf(fields[item] || {}, fieldCfg[item]), me.menuItemCfgs);
					Cls = cfg.fieldCls || me.fieldCls;
					item = fields[item] = Ext.create(Cls, cfg);
				}
				me.add(item);
			}
		},
		stopFn: function(e) { e.stopPropagation(); },
		fireUpdate: function() { this.fireEvent("update", this); },
		getValue: function() {
			const result = {};
			const fields = this.fields;
			var key, field;
			for (key in fields) {
				if (fields.hasOwnProperty(key)) {
					field = fields[key];
					if (field.isValid() && field.getValue() !== null) {
						result[key] = field.getValue();
					}
				}
			}
			return result;
		},
		setValue: function(data) {
			const me = this;
			const fields = me.fields;
			var key, field;
			for (key in fields) {
				if (fields.hasOwnProperty(key)) {
					field = fields[key];
					field.suspendEvents();
					field.setValue(key in data ? data[key] : "");
					field.resumeEvents();
				}
			}
			me.fireEvent("update", me);
		},
		onInputKeyUp: function(field, e) {
			if (e.getKey() === e.RETURN && field.isValid()) {
				e.stopEvent();
				this.hide();
			}
		},
		onInputChange: function(field) {
			const me = this;
			const fields = me.fields;
			const eq = fields.eq;
			const gt = fields.gt;
			const lt = fields.lt;
			if (field == eq) {
				if (gt) {
					gt.setValue(null);
				}
				if (lt) {
					lt.setValue(null);
				}
			} else {
				eq.setValue(null);
			}
			this.updateTask.delay(this.updateBuffer);
		}
	});

Ext.define("Ext.ux.grid.filter.Filter",
	{
		extend: "Ext.util.Observable",
		active: false,
		dataIndex: null,
		menu: null,
		updateBuffer: 500,
		constructor: function(config) {
			Ext.apply(this, config);
			this.addEvents("activate", "deactivate", "serialize", "update");
			Ext.ux.grid.filter.Filter.superclass.constructor.call(this);
			this.menu = this.createMenu(config);
			this.init(config);
			if (config && config.value) {
				this.setValue(config.value);
				this.setActive(config.active !== false, true);
				delete config.value;
			}
		},
		destroy: function() {
			if (this.menu) {
				this.menu.destroy();
			}
			this.clearListeners();
		},
		init: Ext.emptyFn,
		createMenu: function(config) {
			config.plain = true;
			return Ext.create("Ext.menu.Menu", config.menuItems ? { items: config.menuItems, plain: true } : config);
		},
		getValue: Ext.emptyFn,
		setValue: Ext.emptyFn,
		isActivatable: function() { return true; },
		getSerialArgs: Ext.emptyFn,
		validateRecord: function() { return true; },
		serialize: function() {
			const args = this.getSerialArgs();
			this.fireEvent("serialize", args, this);
			return args;
		},
		fireUpdate: function() {
			if (this.active) {
				this.fireEvent("update", this);
			}
			this.setActive(this.isActivatable());
		},
		setActive: function(active, suppressEvent) {
			if (this.active != active) {
				this.active = active;
				if (suppressEvent !== true) {
					this.fireEvent(active ? "activate" : "deactivate", this);
				}
			}
		}
	});

Ext.define("Ext.ux.grid.filter.BooleanFilter",
	{
		extend: "Ext.ux.grid.filter.Filter",
		alias: "gridfilter.boolean",
		defaultValue: false,
		yesText: "Yes",
		noText: "No",
		init: function(config) {
			const gId = Ext.id();
			this.options = [
				Ext.create("Ext.menu.CheckItem",
					{ text: this.yesText, group: gId, checked: this.defaultValue === true }),
				Ext.create("Ext.menu.CheckItem",
					{ text: this.noText, group: gId, checked: this.defaultValue === false })
			];
			this.menu.add(this.options[0], this.options[1]);
			for (let i = 0; i < this.options.length; i++) {
				this.options[i].on("click", this.fireUpdate, this);
				this.options[i].on("checkchange", this.fireUpdate, this);
			}
		},
		getValue: function() { return this.options[0].checked; },
		setValue: function(value) { this.options[value ? 0 : 1].setChecked(true); },
		getSerialArgs: function() {
			const args = { type: "boolean", value: this.getValue() };
			return args;
		},
		validateRecord: function(record) { return record.get(this.dataIndex) == this.getValue(); }
	});

Ext.define("Ext.ux.grid.filter.DateFilter",
	{
		extend: "Ext.ux.grid.filter.Filter",
		alias: "gridfilter.date",
		uses: ["Ext.picker.Date", "Ext.menu.Menu"],
		afterText: "After",
		beforeText: "Before",
		compareMap: { before: "lt", after: "gt", on: "eq" },
		dateFormat: "m/d/Y",
		submitFormat: "Y-m-d\\Th:i:s",
		menuItems: ["before", "after", "-", "on"],
		menuItemCfgs: { selectOnFocus: true, width: 125 },
		onText: "On",
		pickerOpts: {},
		init: function(config) {
			const me = this;
			var pickerCfg, i, len, item, cfg;
			pickerCfg = Ext.apply(me.pickerOpts,
				{
					xtype: "pdatepicker",
					minDate: me.minDate,
					maxDate: me.maxDate,
					format: me.dateFormat,
					listeners: { scope: me, select: me.onMenuSelect }
				});
			me.fields = {};
			for (i = 0, len = me.menuItems.length; i < len; i++) {
				item = me.menuItems[i];
				if (item !== "-") {
					cfg = {
						itemId: `range-${item}`,
						text: me[item + "Text"],
						menu: Ext.create("Ext.menu.Menu",
							{
								plain: true,
								items: [
									Ext.apply(pickerCfg,
										{ itemId: item, listeners: { select: me.onPickerSelect, scope: me } })
								]
							}),
						listeners: { scope: me, checkchange: me.onCheckChange }
					};
					item = me.fields[item] = Ext.create("Ext.menu.CheckItem", cfg);
				}
				me.menu.add(item);
			}
			me.values = {};
		},
		onCheckChange: function(item, checked) {
			const me = this;
			const picker = item.menu.items.first();
			const itemId = picker.itemId;
			const values = me.values;
			if (checked) {
				values[itemId] = picker.getValue();
			} else {
				delete values[itemId];
			}
			me.setActive(me.isActivatable());
			me.fireEvent("update", me);
		},
		onInputKeyUp: function(field, e) {
			const k = e.getKey();
			if (k == e.RETURN && field.isValid()) {
				e.stopEvent();
				this.menu.hide();
			}
		},
		onMenuSelect: function(picker, date) {
			const fields = this.fields;
			const field = this.fields[picker.itemId];
			field.setChecked(true);
			if (field == fields.on) {
				fields.before.setChecked(false, true);
				fields.after.setChecked(false, true);
			} else {
				fields.on.setChecked(false, true);
				if (field == fields.after && this.getFieldValue("before") < date) {
					fields.before.setChecked(false, true);
				} else if (field == fields.before && this.getFieldValue("after") > date) {
					fields.after.setChecked(false, true);
				}
			}
			this.fireEvent("update", this);
			picker.up("menu").hide();
		},
		getValue: function() {
			var key;
			const result = {};
			for (key in this.fields) {
				if (this.fields[key].checked) {
					result[key] = this.getFieldValue(key);
				}
			}
			return result;
		},
		setValue: function(value, preserve) {
			var key;
			for (key in this.fields) {
				if (value[key]) {
					this.getPicker(key).setValue(value[key]);
					this.fields[key].setChecked(true);
				} else if (!preserve) {
					this.fields[key].setChecked(false);
				}
			}
			this.fireEvent("update", this);
		},
		isActivatable: function() {
			var key;
			for (key in this.fields) {
				if (this.fields[key].checked) {
					return true;
				}
			}
			return false;
		},
		getSerialArgs: function() {
			const args = [];
			for (let key in this.fields) {
				if (this.fields[key].checked) {
					args.push({
						type: "date",
						comparison: this.compareMap[key],
						value: Ext.Date.format(this.getFieldValue(key), this.submitFormat)
					});
				}
			}
			return args;
		},
		getFieldValue: function(item) { return this.values[item]; },
		getPicker: function(item) { return this.fields[item].menu.items.first(); },
		validateRecord: function(record) {
			var key, pickerValue, val = record.get(this.dataIndex);
			const clearTime = Ext.Date.clearTime;
			if (!Ext.isDate(val)) {
				return false;
			}
			val = clearTime(val, true).getTime();
			for (key in this.fields) {
				if (this.fields[key].checked) {
					pickerValue = clearTime(this.getFieldValue(key), true).getTime();
					if (key == "before" && pickerValue <= val) {
						return false;
					}
					if (key == "after" && pickerValue >= val) {
						return false;
					}
					if (key == "on" && pickerValue != val) {
						return false;
					}
				}
			}
			return true;
		},
		onPickerSelect: function(picker, date) {
			this.values[picker.itemId] = date;
			this.fireEvent("update", this);
		}
	});

Ext.define("Ext.ux.grid.filter.ListFilter",
	{
		extend: "Ext.ux.grid.filter.Filter",
		alias: "gridfilter.list",
		phpMode: false,
		init: function(config) { this.dt = Ext.create("Ext.util.DelayedTask", this.fireUpdate, this); },
		createMenu: function(config) {
			const menu = Ext.create("Ext.ux.grid.menu.ListMenu", Ext.applyIf(this.menuConfig || {}, config));
			menu.on("checkchange", this.onCheckChange, this);
			return menu;
		},
		getValue: function() { return this.menu.getSelected(); },
		setValue: function(value) {
			this.menu.setSelected(value);
			this.fireEvent("update", this);
		},
		isActivatable: function() { return this.getValue().length > 0; },
		getSerialArgs: function() {
			return{ type: "list", value: this.phpMode ? this.getValue().join(",") : this.getValue() };
		},
		onCheckChange: function() { this.dt.delay(this.updateBuffer); },
		validateRecord: function(record) {
			const valuesArray = this.getValue();
			return Ext.Array.indexOf(valuesArray, record.get(this.dataIndex)) > -1;
		}
	});

Ext.define("Ext.ux.grid.filter.NumericFilter",
	{
		extend: "Ext.ux.grid.filter.Filter",
		alias: "gridfilter.numeric",
		uses: ["Ext.form.field.Number"],
		createMenu: function(config) {
			const me = this;
			const menuCfg = config.menuItems ? { items: config.menuItems } : {};
			var menu;
			if (Ext.isDefined(config.emptyText)) {
				menuCfg.menuItemCfgs = { emptyText: config.emptyText, selectOnFocus: false, width: 155 };
			}
			menu = Ext.create("Ext.ux.grid.menu.RangeMenu", menuCfg);
			menu.on("update", me.fireUpdate, me);
			return menu;
		},
		getValue: function() { return this.menu.getValue(); },
		setValue: function(value) { this.menu.setValue(value); },
		isActivatable: function() {
			const values = this.getValue();
			var key;
			for (key in values) {
				if (values[key] !== undefined) {
					return true;
				}
			}
			return false;
		},
		getSerialArgs: function() {
			var key;
			const args = [];
			const values = this.menu.getValue();
			for (key in values) {
				args.push({ type: "numeric", comparison: key, value: values[key] });
			}
			return args;
		},
		validateRecord: function(record) {
			const val = record.get(this.dataIndex);
			const values = this.getValue();
			const isNumber = Ext.isNumber;
			if (isNumber(values.eq) && val != values.eq) {
				return false;
			}
			if (isNumber(values.lt) && val >= values.lt) {
				return false;
			}
			if (isNumber(values.gt) && val <= values.gt) {
				return false;
			}
			return true;
		}
	});

Ext.define("Ext.ux.grid.filter.StringFilter",
	{
		extend: "Ext.ux.grid.filter.Filter",
		alias: "gridfilter.string",
		iconCls: "ux-gridfilter-text-icon",
		emptyText: "Enter Filter Text...",
		selectOnFocus: true,
		width: 125,
		init: function(config) {
			Ext.applyIf(config,
				{
					enableKeyEvents: true,
					labelCls: `ux-rangemenu-icon ${this.iconCls}`,
					hideEmptyLabel: false,
					labelSeparator: "",
					labelWidth: 29,
					listeners: {
						scope: this,
						keyup: this.onInputKeyUp,
						el: { click: function(e) { e.stopPropagation(); } }
					}
				});
			this.inputItem = Ext.create("Ext.form.e.Value.ToString()", config);
			this.menu.add(this.inputItem);
			this.menu.showSeparator = false;
			this.updateTask = Ext.create("Ext.util.DelayedTask", this.fireUpdate, this);
		},
		getValue: function() { return this.inputItem.getValue(); },
		setValue: function(value) {
			this.inputItem.setValue(value);
			this.fireEvent("update", this);
		},
		isActivatable: function() { return this.inputItem.getValue().length > 0; },
		getSerialArgs: function() { return{ type: "string", value: this.getValue() }; },
		validateRecord: function(record) {
			const val = record.get(this.dataIndex);
			if (typeof val != "string") {
				return(this.getValue().length === 0);
			}
			return val.toLowerCase().indexOf(this.getValue().toLowerCase()) > -1;
		},
		onInputKeyUp: function(field, e) {
			const k = e.getKey();
			if (k == e.RETURN && field.isValid()) {
				e.stopEvent();
				this.menu.hide();
				return;
			}
			this.updateTask.delay(this.updateBuffer);
		}
	});

Ext.define("Ext.ux.grid.FiltersFeature",
	{
		extend: "Ext.grid.feature.Feature",
		alias: "feature.filters",
		uses: [
			"Ext.ux.grid.menu.ListMenu", "Ext.ux.grid.menu.RangeMenu", "Ext.ux.grid.filter.BooleanFilter",
			"Ext.ux.grid.filter.DateFilter", "Ext.ux.grid.filter.ListFilter", "Ext.ux.grid.filter.NumericFilter",
			"Ext.ux.grid.filter.StringFilter"
		],
		mixins: { observable: "Ext.util.Observable" },
		isGridFiltersPlugin: true,
		autoReload: true,
		encode: true,
		filterCls: "ux-filtered-column",
		local: false,
		menuFilterText: "Filters",
		paramPrefix: "filter",
		showMenu: true,
		stateId: undefined,
		updateBuffer: 500,
		hasFeatureEvent: false,
		constructor: function(config) {
			const me = this;
			config = config || {};
			Ext.apply(me, config);
			me.deferredUpdate = Ext.create("Ext.util.DelayedTask", me.reload, me);
			me.filters = me.createFiltersCollection();
			me.filterConfigs = config.filters;
		},
		init: function(grid) {
			const me = this;
			const view = me.view;
			const headerCt = view.headerCt;
			me.bindStore(view.getStore(), true);
			headerCt.on("menucreate", me.onMenuCreate, me);
			view.on("refresh", me.onRefresh, me);
			grid.on({
				scope: me,
				beforestaterestore: me.applyState,
				beforestatesave: me.saveState,
				beforedestroy: me.destroy
			});
			grid.filters = me;
			me.addEvents("filterupdate");
			me.mixins.observable.constructor.call(me);
		},
		ensureFilters: function() {
			if (this.view && this.view.headerCt && !this.view.headerCt.menu) {
				this.view.headerCt.getMenu();
			}
		},
		createFiltersCollection: function() {
			return Ext.create("Ext.util.MixedCollection", false, function(o) { return o ? o.dataIndex : null; });
		},
		createFilters: function() {
			const me = this;
			const hadFilters = me.filters.getCount();
			const grid = me.getGridPanel();
			var filters = me.createFiltersCollection();
			const model = grid.store.model;
			var fields = model.prototype.fields,
				field,
				filter,
				state;
			if (hadFilters) {
				state = {};
				me.saveState(null, state);
			}

			function add(dataIndex, config, filterable) {
				if (dataIndex && (filterable || config)) {
					field = fields.get(dataIndex);
					filter = { dataIndex: dataIndex, type: (field && field.type && field.type.type) || "auto" };
					if (Ext.isObject(config)) {
						Ext.apply(filter, config);
					}
					filters.replace(filter);
				}
			}

			Ext.Array.each(me.filterConfigs, function(filterConfig) { add(filterConfig.dataIndex, filterConfig); });
			Ext.Array.each(grid.columns,
				function(column) {
					if (column.filterable === false) {
						filters.removeAtKey(column.dataIndex);
					} else {
						add(column.dataIndex, column.filter, column.filterable);
					}
				});
			me.removeAll();
			if (filters.items) {
				me.initializeFilters(filters.items);
			}
			if (hadFilters) {
				me.applyState(null, state);
			}
		},
		initializeFilters: function(filters) {
			const me = this;
			const filtersLength = filters.length;
			var i, filter, FilterClass;
			for (i = 0; i < filtersLength; i++) {
				filter = filters[i];
				if (filter) {
					FilterClass = me.getFilterClass(filter.type);
					filter = filter.menu ? filter : new FilterClass(filter);
					me.filters.add(filter);
					Ext.util.Observable.capture(filter, this.onStateChange, this);
				}
			}
		},
		onMenuCreate: function(headerCt, menu) {
			const me = this;
			me.createFilters();
			menu.on("beforeshow", me.onMenuBeforeShow, me);
		},
		onMenuBeforeShow: function(menu) {
			const me = this;
			var menuItem, filter;
			if (me.showMenu) {
				menuItem = me.menuItem;
				if (!menuItem || menuItem.isDestroyed) {
					me.createMenuItem(menu);
					menuItem = me.menuItem;
				}
				filter = me.getMenuFilter();
				if (filter) {
					menuItem.setMenu(filter.menu, false);
					menuItem.setChecked(filter.active);
					menuItem.setDisabled(filter.disabled === true);
				}
				menuItem.setVisible(!!filter);
				this.sep.setVisible(!!filter);
			}
		},
		createMenuItem: function(menu) {
			const me = this;
			me.sep = menu.add("-");
			me.menuItem = menu.add({
				checked: false,
				itemId: "filters",
				text: me.menuFilterText,
				listeners: { scope: me, checkchange: me.onCheckChange, beforecheckchange: me.onBeforeCheck }
			});
		},
		getGridPanel: function() { return this.view.up("gridpanel"); },
		applyState: function(grid, state) {
			const me = this;
			var key, filter;
			me.applyingState = true;
			me.clearFilters();
			if (state.filters) {
				for (key in state.filters) {
					if (state.filters.hasOwnProperty(key)) {
						filter = me.filters.get(key);
						if (filter) {
							filter.setValue(state.filters[key]);
							filter.setActive(true);
						}
					}
				}
			}
			me.deferredUpdate.cancel();
			if (me.local) {
				me.reload();
			}
			delete me.applyingState;
			delete state.filters;
		},
		saveState: function(grid, state) {
			var filters = {};
			this.filters.each(function(filter) {
				if (filter.active) {
					filters[filter.dataIndex] = filter.getValue();
				}
			});
			return(state.filters = filters);
		},
		destroy: function() {
			const me = this;
			Ext.destroyMembers(me, "menuItem", "sep");
			me.removeAll();
			me.clearListeners();
		},
		removeAll: function() {
			if (this.filters) {
				Ext.destroy.apply(Ext, this.filters.items);
				this.filters.clear();
			}
		},
		bindStore: function(store) {
			const me = this;
			if (me.store && me.storeListeners) {
				me.store.un(me.storeListeners);
			}
			if (store) {
				me.storeListeners = { scope: me };
				if (me.local) {
					me.storeListeners.load = me.onLoad;
				} else {
					me.storeListeners[`before${store.buffered ? "prefetch" : "load"}`] = me.onBeforeLoad;
				}
				store.on(me.storeListeners);
			} else {
				delete me.storeListeners;
			}
			me.store = store;
		},
		getMenuFilter: function() {
			const header = this.view.headerCt.getMenu().activeHeader;
			return header ? this.filters.get(header.dataIndex) : null;
		},
		onCheckChange: function(item, value) { this.getMenuFilter().setActive(value); },
		onBeforeCheck: function(check, value) { return!value || this.getMenuFilter().isActivatable(); },
		onStateChange: function(event, filter) {
			if (event !== "serialize") {
				const me = this;
				const grid = me.getGridPanel();
				if (filter == me.getMenuFilter()) {
					me.menuItem.setChecked(filter.active, false);
				}
				if ((me.autoReload || me.local) && !me.applyingState) {
					me.deferredUpdate.delay(me.updateBuffer);
				}
				me.updateColumnHeadings();
				if (!me.applyingState) {
					grid.saveState();
				}
				this.fireEvent("filterupdate", me, filter);
			}
		},
		onBeforeLoad: function(store, options) {
			if (!options) {
				return;
			}
			this.ensureFilters();
			options.params = options.params || {};
			this.cleanParams(options.params);
			const params = this.buildQuery(this.getFilterData());
			Ext.apply(options.params, params);
		},
		onLoad: function(store, options) { store.filterBy(this.getRecordFilter()); },
		onRefresh: function() { this.updateColumnHeadings(); },
		updateColumnHeadings: function() {
			var me = this;
			const headerCt = me.view.headerCt;
			if (headerCt) {
				headerCt.items.each(function(header) {
					const filter = me.getFilter(header.dataIndex);
					header[filter && filter.active ? "addCls" : "removeCls"](me.filterCls);
				});
			}
		},
		reload: function() {
			const me = this;
			const store = me.view.getStore();
			if (me.local) {
				store.clearFilter(true);
				store.filterBy(me.getRecordFilter());
				store.sort();
			} else {
				me.deferredUpdate.cancel();
				if (store.buffered) {
					store.data.clear();
				}
				store.loadPage(1);
			}
		},
		getRecordFilter: function() {
			var f = [], len, i;
			this.filters.each(function(filter) {
				if (filter.active) {
					f.push(filter);
				}
			});
			len = f.length;
			return function(record) {
				for (i = 0; i < len; i++) {
					if (!f[i].validateRecord(record)) {
						return false;
					}
				}
				return true;
			};
		},
		addFilter: function(config) {
			const me = this;
			const columns = me.getGridPanel().columns;
			var i, columnsLength, column, filtersLength, filter;
			for (i = 0, columnsLength = columns.length; i < columnsLength; i++) {
				column = columns[i];
				if (column.dataIndex === config.dataIndex) {
					column.filter = config;
				}
			}
			if (me.view.headerCt.menu) {
				me.createFilters();
			} else {
				me.view.headerCt.getMenu();
			}
			for (i = 0, filtersLength = me.filters.items.length; i < filtersLength; i++) {
				filter = me.filters.items[i];
				if (filter.dataIndex === config.dataIndex) {
					return filter;
				}
			}
		},
		addFilters: function(filters) {
			if (filters) {
				const me = this;
				let i;
				let filtersLength;
				for (i = 0, filtersLength = filters.length; i < filtersLength; i++) {
					me.addFilter(filters[i]);
				}
			}
		},
		getFilter: function(dataIndex) {
			this.ensureFilters();
			return this.filters.get(dataIndex);
		},
		clearFilters: function() { this.filters.each(function(filter) { filter.setActive(false); }); },
		getFilterItems: function() {
			const me = this;
			if (me.lockingPartner) {
				return me.filters.items.concat(me.lockingPartner.filters.items);
			}
			return me.filters.items;
		},
		getFilterData: function() {
			const items = this.getFilterItems();
			const filters = [];
			var n, nlen, item, d, i, len;
			for (n = 0, nlen = items.length; n < nlen; n++) {
				item = items[n];
				if (item.active) {
					d = [].concat(item.serialize());
					for (i = 0, len = d.length; i < len; i++) {
						filters.push({ field: item.dataIndex, data: d[i] });
					}
				}
			}
			return filters;
		},
		buildQuery: function(filters) {
			if (this.view.getStore().proxy && this.view.getStore().proxy.isODataProxy) {
				return this.buildQueryOdata(filters);
			}
			const p = {};
			var i, f, root, dataPrefix, key, tmp;
			const len = filters.length;
			if (!this.encode) {
				for (i = 0; i < len; i++) {
					f = filters[i];
					root = [this.paramPrefix, "[", i, "]"].join("");
					p[root + "[field]"] = f.field;
					dataPrefix = root + "[data]";
					for (key in f.data) {
						p[[dataPrefix, "[", key, "]"].join("")] = f.data[key];
					}
				}
			} else {
				tmp = [];
				for (i = 0; i < len; i++) {
					f = filters[i];
					tmp.push(Ext.apply({}, { field: f.field }, f.data));
				}
				if (tmp.length > 0) {
					p[this.paramPrefix] = Ext.JSON.encode(tmp);
				}
			}
			return p;
		},
		buildQueryOdata: function(filters) {
			const p = {};
			var i, f, dataPrefix;
			const len = filters.length;
			var odata = "",
				value;
			for (i = 0; i < len; i++) {
				f = filters[i];
				if (odata != "") {
					odata += " and ";
				}
				if (f.data.type == "list") {
					Ext.each(f.data.value,
						function(v, index) {
							value = `'${v}'`;
							if (index > 0) {
								odata += " or ";
							} else {
								odata += "(";
							}
							odata += `substringof(${value},${f.field}) eq true`;
							if (index == (f.data.value.length - 1)) {
								odata += ")";
							}
						});
				} else {
					value =
						(f.data.type == "string" || f.data.type == "date") ? `'${f.data.value}'` : f.data.value;
					if (f.data.type == "date") {
						value = `datetime${value}`;
					}
					if (f.data.comparison != null) {
						odata += f.field + " " + f.data.comparison + " " + value;
					} else {
						odata += `substringof(${value},${f.field}) eq true`;
					}
				}
			}
			if (odata != "") {
				p["$filter"] = odata;
			}
			return p;
		},
		cleanParams: function(p) {
			if (this.encode) {
				delete p[this.paramPrefix];
			} else {
				let regex;
				let key;
				regex = new RegExp(`^${this.paramPrefix}\[[0-9]+\]`);
				for (key in p) {
					if (regex.test(key)) {
						delete p[key];
					}
				}
			}
		},
		getFilterClass: function(type) {
			switch (type) {
			case"auto":
				type = "string";
				break;
			case"int":
			case"float":
				type = "numeric";
				break;
			case"bool":
				type = "boolean";
				break;
			}
			return Ext.ClassManager.getByAlias(`gridfilter.${type}`);
		}
	});
Ext.ux.grid.FiltersFeature.override(Ext.util.DirectObservable);