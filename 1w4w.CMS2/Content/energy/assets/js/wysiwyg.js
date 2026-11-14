<!--
	//Image/icon boxes
	function showImageBox(oContainer1, oContainer2) {
		document.getElementById(oContainer1).style.visibility = 'visible';
		document.getElementById(oContainer2).style.visibility = 'visible';
	}

function closeImageBox(oContainer1, oContainer2, oContainer3) {
	document.getElementById(oContainer1).style.visibility = 'hidden';
	document.getElementById(oContainer2).style.visibility = 'hidden';
	document.getElementById(oContainer3).style.visibility = 'hidden';
}



function insertImage(oContainer, sImageUrl) {

	document.getElementById(oContainer).value += '\n<img src="' + sImageUrl + '" border="0">';

	//document.frmEdit.linkContent1.value+='\n<img src="' + sImageUrl + '" border="0">';

	closeImageBox('imageBox1', 'imageBox2', 'iconBox1');

	closeImageBox('imageBox3', 'imageBox4', 'iconBox2');

	closeImageBox('imageBox5', 'imageBox6', 'iconBox3');

}



function insertTag(sOpeningTag, sClosingTag, oContainer) {

	theSelection = document.selection.createRange().text;	// Get text selection



	if (theSelection) {										// If text is selected add tags around selection

		document.selection.createRange().text = sOpeningTag + theSelection + sClosingTag;

		document.getElemenyById(oContainer).focus();

		theSelection = '';

		return;

	}

	else {													// If no text is selected add tags at last position in the field

		document.getElementById(oContainer).value += sOpeningTag + sClosingTag;

	}

}



//Messages

function helpMessage(iNumber, oContainer) {

	arrHelpMessage = new Array('Gör texten <b>fet</b>', 'Gör texten <i>kursiv</i>', 'Gör texten <u>understruken</u>', 'Gör texten till en rubrik', 'Gör texten till en länk som öppnas i samma fönster', 'Gör texten till en länk som öppnas i ett nytt fönster', 'Gör texten till en lista. Du kan själv lägga till fler punkter genom att göra fler &lt;li&gt;punkter&lt;/li&gt;', 'Infoga en tabell med 3 kolumner som du enkelt kan ändra till 2 kolumner', 'Infogar en bild', 'Infogar en 4px hög utfyllnad', 'Infogar en ikon')

	if (iNumber != '') {

		document.getElementById(oContainer).innerHTML = arrHelpMessage[iNumber];

	}

	else {

		document.getElementById(oContainer).innerHTML = '';

	}

}



//Button styles

function selOn(oObject) {

	oObject.style.borderColor = '#000000';

	oObject.style.backgroundColor = '#BBD9FF';

	oObject.style.cursor = 'hand';

}



function selOff(oObject) {

	oObject.style.borderColor = '#000000';

	oObject.style.backgroundColor = '#8BBDFF';

}



function selDown(oObject) {

	oObject.style.backgroundColor = '#8492B5';

}



function selUp(oObject) {

	oObject.style.backgroundColor = '#B5BED6';

}





//Help Message

function showMessage(sMessage, oContainer) {

	document.getElementById(oContainer).visibility = 'visible';

	document.getElementById(oContainer).innerHTML = sMessage;

}

function hideMessage(oContainer) {
	document.getElementById(oContainer).visibility = 'hidden';
	document.getElementById(oContainer).innerHTML = '';
}
-->