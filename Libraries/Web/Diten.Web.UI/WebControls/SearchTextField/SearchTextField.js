Ext.namespace("Ext.ux.form");

Ext.ux.form.SearchTextField = function(config) {
	Ext.ux.form.SearchTextField.superclass.constructor.call(this, config);
};

Ext.ux.form.SearchTextField = Ext.extend(Ext.form.TextField,
	{
		searchModeEnabled: true,
		failureFn: null,
		successFn: null,
		searchUrl: null,
		extraParameterName: "identificador",

		initComponent: function() {
			Ext.ux.form.SearchTextField.superclass.initComponent.call(this);
		},

		// private
		initEvents: function() {
			Ext.ux.form.SearchTextField.superclass.initEvents.call(this);
		},

		onRender: function(ct, position) {
			Ext.ux.form.SearchTextField.superclass.onRender.call(this, ct, position);
		}
	});

Ext.reg("searchtextfield", Ext.ux.form.SearchTextField);