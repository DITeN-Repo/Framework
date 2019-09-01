let frontWindowId;
let screenWidth;
let screenHeight;

class Desktop extends HTMLDivElement {
	constructor() {
		super();
	}
}

class Container extends HTMLDivElement {
	constructor() {
		super();
	}
}

class Window extends HTMLDivElement {
	constructor() {
		super();
	}
}

class Taskbar extends HTMLDivElement {
	constructor() {
		super();
	}
}

class Header extends HTMLDivElement {
	constructor() {
		super();
	}
}

function Initialize() {
	customElements.define("desktop", Desktop);
	customElements.define("container", Container);
	customElements.define("window", Window);
	customElements.define("taskbar", Taskbar);
	customElements.define("header", Header);
}

function setWindowPosition(windowId, x, y) {
	getWindow(windowId).left = x;
	getWindow(windowId).top = y;
}
//function tileWindows() {
//    var windowsCount = document.getElementById('window*');
//    Screen.Desktop.Windows
//    for (var i = 0; i=)

let Screen;
Screen = [
	{
		Dimention: function getDimention() {
			let Width;
			let Height;
			return [Width = document["screenWidth"], Height = document["screenHeight"]];
		},
		Desktop: function getDesktop() {
			alert("dddd");
			const desktopObj = document.getElementsByTagName("desktop")[0];
			let Windows;
			return [
				{
					desktopObj,
					Windows: Windows = function getWindows(desktopObjHolder = desktopObj) {
						const windowsObj = {};
						const windowElement = desktopObjHolder.getElementsByTagName("window");
						const windowElementCounts = windowElement.childElementCount;
						for (const i = 0; i <= windowElementCounts;) {
							windowsObj[windowElement[i].id] = windowElement;
						}
						return windowsObj;
					}
				}
			];
		}
	}
];

//}
function getWindow(windowId) {
	return Screen.Desktop.Windows[windowId];
}

screenWidth = undefined;

function ChangeZIndexToTop(windowId) {
	const backWindow = Screen.Desktop.Windows[windowId];
	const backWindowZIndex = backWindow.style.zIndex;
	backWindow.style.zIndex = 1000;
	if (frontWindowId === "") {
		frontWindowId = windowId;
	} else {
		let frontWindow;
		frontWindow = Screen.Desktop.Windows[frontWindowId];
		let frontWindowZIndex;
		frontWindowZIndex = frontWindow.style.zIndex;
		backWindow.style.zIndex = frontWindowZIndex;
		frontWindow.style.zIndex = backWindowZIndex;
	}
}


let oldWindow = null;

//Make the DIV element draggable:
dragElement(Screen.Desktop.Windows["Window1"]);
dragElement(Screen.Desktop.Windows["Window2"]);

function dragElement(element) {
	let pos1 = 0, pos2 = 0, pos3 = 0, pos4 = 0;
	//var element = element.getElementById(element.id + '_div')

	//alert(element.id);
	if (document.getElementById(element.id + "_header")) {
		/* if present, the header is where you move the DIV from:*/
		document.getElementById(element.id + "_header").onmousedown = dragMouseDown;
	} else {
		/* otherwise, move the DIV from anywhere inside the DIV:*/
		element.onmousedown = dragMouseDown;
	}

	function dragMouseDown(e) {


		e = e || window.event;
		e.preventDefault();
		// get the mouse cursor position at startup:
		pos3 = e.clientX;
		pos4 = e.clientY;
		document.onmouseup = closeDragElement;
		// call a function whenever the cursor moves:
		document.onmousemove = elementDrag;
	}

	function elementDrag(e) {
		e.target.style.zIndex = e.target.style.zIndex + 1;
		e = e || window.event;
		e.preventDefault();
		// calculate the new cursor position:
		pos1 = pos3 - e.clientX;
		pos2 = pos4 - e.clientY;
		pos3 = e.clientX;
		pos4 = e.clientY;
		// set the element's new position:
		element.style.top = (element.offsetTop - pos2) + "px";
		element.style.left = (element.offsetLeft - pos1) + "px";

		oldWindow = e.target;
	}

	function closeDragElement() {
		/* stop moving when mouse button is released:*/
		document.onmouseup = null;
		document.onmousemove = null;
	}
}