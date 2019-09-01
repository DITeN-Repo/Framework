
class DivElementw extends HTMLElement {
	constructor() {
		super();
		const DesktopSElement = document.createElement("DesktopS");
		const shadow = this.attachShadow({ mode: "open" });
		const divElement = document.createElement("div");

		divElement.setAttribute("class", "Desktopc");
		DesktopSElement.appendChild(divElement);

		shadow.appendChild(DesktopSElement);
		//divElement.setAttribute("class", 'Desktop');
		//divElement.setAttribute("style", this.getAttribute("style"));
		//divElement.setAttribute("id", this.getAttribute("id") + "_div");
		//this.setAttribute("class", null);
		//this.setAttribute("style", null);
		//document.appendChild(divElement)
	}
}


class DivElement extends HTMLElement {

	// A getter/setter for an open property.
	get open() {
		return this.hasAttribute("open");
	}

	set open(val) {
		// Reflect the value of the open property as an HTML attribute.
		if (val) {
			this.setAttribute("open", "");
		} else {
			this.removeAttribute("open");
		}
		this.toggleDrawer();
	}

	// A getter/setter for a disabled property.
	get disabled() {
		return this.hasAttribute("disabled");
	}

	set disabled(val) {
		// Reflect the value of the disabled property as an HTML attribute.
		if (val) {
			this.setAttribute("disabled", "");
		} else {
			this.removeAttribute("disabled");
		}
	}

	// Can define constructor arguments if you wish.
	constructor() {
		// If you define a constructor, always call super() first!
		// This is specific to CE and required by the spec.
		super();
		const DesktopSElement = document.createElement("DesktopS");
		const shadow = this.attachShadow({ mode: "open" });
		const divElement = document.createElement("div");

		divElement.setAttribute("class", "Desktopc");
		DesktopSElement.appendChild(divElement);

		shadow.appendChild(DesktopSElement);
		// Setup a click listener on <app-drawer> itself.
		this.addEventListener("click",
			e => {
				// Don't toggle the drawer if it's disabled.
				if (this.disabled) {
					return;
				}
				this.toggleDrawer();
			});
	}

	toggleDrawer() {
	}
}


class Desktop extends DivElement {
	constructor() {
		super();
		//this.setAttribute("class", "Desktop");
	}
}

/*
class SpanElement extends HTMLSpanElement {
    constructor() {
        super();
    }
}
class InputElement extends HTMLInputElement {
    constructor() {
        super();
    }
}

class Container extends DivElement {
    constructor() {
        super();
    }
}
class Window extends DivElement {
    constructor() {
        super();
    }
}
class TaskBar extends DivElement {
    constructor() {
        super();
    }
}
class TitleBar extends DivElement {
    constructor() {
        super();
    }
}
class ToolBar extends DivElement {
    constructor() {
        super();
    }
}
class Column extends DivElement {
    constructor() {
        super();
    }
}
class Box extends Column {
    constructor() {
        super();
    }
}
class Bar extends SpanElement {
    constructor() {
        super();
    }
}
class DialogButton extends SpanElement {
    constructor() {
        super();
    }
}
class StatusBar extends DivElement {
    constructor() {
        super();
    }
}
class ContentHolder extends DivElement {
    constructor() {
        super();
    }
}
class NorthBox extends DivElement {
    constructor() {
        super();
    }
}
class WestBox extends DivElement {
    constructor() {
        super();
    }
}
class EastBox extends DivElement {
    constructor() {
        super();
    }
}
class SouthBox extends DivElement {
    constructor() {
        super();
    }
}
class CenterBox extends DivElement {
    constructor() {
        super();
    }
}
class TextBox extends InputElement {
    constructor() {
        super();
        this.Initialize();
    }

    Initialize() {
        this.type="text";
        this.setAttribute("style", "background-color: #ED594A;");
    }
}
*/
function Initialize() {
	//alert("Start");
	document.createElement("DesktopS");
	customElements.define("DesktopS", DivElement);
	//window.customElements.define('DesktopS', Desktop);
	alert("1");
	return;

	customElements.define("Desktop", Desktop);
	customElements.define("Container", Container);
	customElements.define("Window", Window);
	customElements.define("Bar", Bar);
	customElements.define("Box", Box);
	customElements.define("TaskBar", TaskBar);
	customElements.define("TitleBar", TitleBar);
	customElements.define("TitleBar", ToolBar);
	customElements.define("DialogButton", DialogButton);
	customElements.define("ContentHolder", ContentHolder);
	customElements.define("StatusBar", StatusBar);
	customElements.define("NorthBox", NorthBox);
	customElements.define("WestBox", WestBox);
	customElements.define("SouthBox", SouthBox);
	customElements.define("EastBox", EastBox);
	customElements.define("CenterBox", CenterBox);
	customElements.define("TextBox", TextBox);
	alert("End");

}