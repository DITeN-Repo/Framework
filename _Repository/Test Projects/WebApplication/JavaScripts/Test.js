//String.prototype.replaceAll = function(search, replacement) {
//    var target = this;
//   return target.replace(new RegExp(search, 'g'), replacement);
// };

function dragElement(element) {
	let pos1 = 0, pos2 = 0, pos3 = 0, pos4 = 0;
	element.onmousedown = dragMouseDown;
	const desk = document.getElementById("Desktop1");

	function dragMouseDown(e) {
		e = e || window.event;
		e.preventDefault();
		// get the mouse cursor position at startup:
		pos3 = e.clientX;
		pos4 = e.clientY;
		desk.onmouseup = closeDragElement;
		// call a function whenever the cursor moves:
		desk.onmousemove = elementDrag;
	}

	function elementDrag(e) {
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

	}

	function closeDragElement() {
		/* stop moving when mouse button is released:*/
		desk.onmouseup = null;
		desk.onmousemove = null;
	}
}

function textboxMouseDown(obj) {
	obj.style = "background-color: red;";
}

dragElement(document.getElementById("window2"));