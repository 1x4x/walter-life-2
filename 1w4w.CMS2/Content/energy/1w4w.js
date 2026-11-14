function toggle(element)
{
    var x = document.getElementById(element);
    if (x.style.display === "none")
    {
        x.style.display = "block";
    } else {
        x.style.display = "none";
    }
}

//function makenumeric(element) {
//    if (element.value < 0) element.value = 1;
//    if (element.value == '') element.value = 1;
//return element.value !== '' &&
//Boolean(expression)
//}

//  onkeyup="if (this.value < 0) this.value = 1; if (this.value == '') this.value = 1;" onblur="if(this.value<0)this.value=1"

function isNumber(evt)
{
    evt = (evt) ? evt : window.event;
    let charCode = (evt.which) ? evt.which : evt.keyCode;
    if ((charCode > 31 && (charCode < 48 || charCode > 57)) && charCode !== 46) {
        evt.preventDefault();
    } else {
        return true;
    }
}

function clearordercontainer() {
    var div1 = document.getElementById('ordercontainer');
    div1.style.display = 'block';
    div1.innerHTML = 'Inget i varukorgen';

    document.getElementById("ordercontainer2cleandata").value = document.getElementById('ordercontainer2cleandata').value = "";


    let basketcountdiv = document.getElementById('basketcountdiv');
    basketcountdiv.setAttribute('data-count', 0);
}


function addtobasket(id, amount, artnr, name) {
    // add the html that the user see to the ordercontainer div
    var div1 = document.getElementById('ordercontainer');
    div1.style.display = 'block';
    div1.innerHTML = div1.innerHTML.replace('Inget i varukorgen', '');
    div1.innerHTML = "<p><i class='fa-solid fa-tags' style='color: #1dc2cf;'></i> " + amount + " st " + name + "</p>" + div1.innerHTML;


    // create a cleaner format thats easier to parse in the /order/create controller. just separate by _
    //var ordercontainer2cleandata = document.getElementById('ordercontainer2cleandata');
    var cleandata = id + '_' + amount + '_' + artnr + '_' + name + '¤';
    //alert('amount: ' + amount);
    // put clean data into the ordercontainer2cleandata hidden field
    //var ordercontainer2cleandata = document.getElementById('ordercontainer2cleandata');
    document.getElementById("ordercontainer2cleandata").value = document.getElementById("ordercontainer2cleandata").value + '¤' + cleandata;





    // https://gomakethings.com/how-to-get-set-and-remove-data-attributes-with-vanilla-javascript/
    let basketcountdiv = document.getElementById('basketcountdiv');

    // Get the value of the [data-click] attribute
    // returns "count"
    //let click = btn.getAttribute('data-click');

    // Set a value for the [data-count] attribute
    // <button data-count="up">Count Up</button>
    basketcountdiv.setAttribute('data-count', (parseInt(basketcountdiv.getAttribute('data-count')) + parseInt(amount)));
    //alert('basketcountdiv: ' + basketcountdiv.getAttribute('data-count'));


}









function insertselectedimagepath(imagepath) {
    if (document.readyState === "complete") {

        var figure = document.createElement('figure');
        $(figure).html('<img src="' + '/content/upload/image/1005.jpg' + '" alt="">');
        //var easyeditor = document.getElementById('editor');
        //_this.insertAtCaret(figure);
        //$('#myTextarea').insertAtCaret(figure)
        //var easyeditor = new EasyEditor('#editor');
        console.log(figure);
        $('#editor').insertAtCaret(figure);









        var figure = document.createElement('figure');
        $(figure).html('<img src="' + imagepath + '" alt="">');



        //alert(imagepath);
        //var easyeditor = document.getElementById('#editor');
        //var easyeditor = document.getElementById('editor');
        //alert(easyeditor.innerHTML);
        //easyeditor.innerHTML = figure;







        //if (imagepath.length > 0) {

        //    var figure = document.createElement('figure');
        //    $(figure).html('<img src="' + imagepath + '" alt="">');

        //    var easyeditor = document.getElementById('#editor');
        //    console.log(figure);

        //    var currenthtml = easyeditor.innerHTML();
        //    easyeditor.innerHTML = currenthtml + '<img src="' + imagepath + '" alt="">';
        //    document.getElementById('iconBox1').style.display = "none";
        //}






        //if (imagepath.length > 0) {
        if (imagepath == undefined) {
            alert('imagepath == undefined');
            return;
        }
        else {
            //alert(imagepath);
            var figure = document.createElement('figure');
            $(figure).html('<img src="' + imagepath + '" alt="">');
            //_this.insertAtCaret(figure);
            //$('#myTextarea').insertAtCaret(figure)


            //var easyeditor = new EasyEditor('#editor');
            var easyeditor = document.getElementById('editor');

            console.log(figure);
            $('#editor').insertAtCaret(figure)
            //easyeditor.insertHtml('<figure><img src="uploader_sdk/images/' + get.responseText + '" alt=""></figure>');
            //var currenthtml = easyeditor.innerHTML();
            //easyeditor.innerHTML = currenthtml + '<img src="' + imagepath + '" alt="">';

            //document.getElementById('iconBox1').style.visibility = "hidden";
            document.getElementById('iconBox1').style.display = "none";
        }
    }
    // Fully loaded!
}



// CKEditor:Start
$.fn.insertAtCaret = function (myValue) {
    return this.each(function () {
        var me = this;
        if (document.selection) { // IE
            me.focus();
            sel = document.selection.createRange();
            sel.text = myValue;
            me.focus();
        } else if (me.selectionStart || me.selectionStart == '0') { // Real browsers
            var startPos = me.selectionStart, endPos = me.selectionEnd, scrollTop = me.scrollTop;
            me.value = me.value.substring(0, startPos) + myValue + me.value.substring(endPos, me.value.length);
            me.focus();
            me.selectionStart = startPos + myValue.length;
            me.selectionEnd = startPos + myValue.length;
            me.scrollTop = scrollTop;
        } else {
            me.value += myValue;
            me.focus();
        }
    });
};
// CKEditor:End





function changefontsizeonelement(element, fontsize) {
    var element2 = document.getElementById(element);
    element2.style.fontsize = fontsize + "px";
    //span.innerHTML = "asdfasdasdf";
}




async function createFileTagInClipboard(text) {
    try {
        await navigator.clipboard.writeText('<a href="' + text + '">' + text + '</a>');
        console.log('Content copied to clipboard');
        alert('Copied <a href="' + text + '">' + text + '</a> to clipboard');
    } catch (err) {
        /* Rejected - text failed to copy to the clipboard */
    }
}

async function createImageTagInClipboard(text) {
    try {
        await navigator.clipboard.writeText('<img src="' + text + '">');
        console.log('Content copied to clipboard');
        /* Resolved - text copied to clipboard successfully */
        alert('Copied ' + '<img src="' + text + '">' + ' to clipboard');
    } catch (err) {
        console.error('Failed to copy: ', err);
        /* Rejected - text failed to copy to the clipboard */
    }
}

// https://stackoverflow.com/questions/7770187/returning-a-boolean-value-in-a-javascript-function
function isValidPassword() {
    //function validatePassword() {
    const password = document.getElementById("password");
    const confirm_password = document.getElementById("password_confirm");
    if (password.value.length === 0) { return false };
    if (password.value !== confirm_password.value) { return false };
    return true;
}



function selectImage(path) {
    //jQuery(document).ready(function ($) {
    //    var editor = new EasyEditor('#editor');
    //});


    //$('#editor').EasyEditor().prototype.pung1(path);
}

// #editor1 - script to get changes made into the div
// editor1 into the hidden input field text1
//$(document).ready(function () {
//    $('#editor1').bind("contentchange", function () {
//        alert("pppp");// how to capture this event
//    });

//    $("#btn").click(function () {
//        $('#editor1').html("hsdhsdhf").trigger("contentchange");
//    });
//});

//$.ajax({
//    //...,
//    success: function () {
//           //...other things ...
//           //...setting div text ...
//    calculateTotal();
//    }
//});







/*
Filter divs
*/
function wfilter(filter) {
    const elements = document.getElementsByClassName('filterdiv');
    console.log('elements: ' + elements);
    //alert(elements);
    //el.classList.remove("red");
    //document.getElementById("whatever").classList.remove("className");
}










//filterSelection("Catering")
function filterselection2(c) {
    var x, i;
    //x = document.getElementsByClassName("filterdiv");
    x = document.getElementsByClassName("filterdiv");
    //x0 = document.getElementsByClassName("uploadedimagecontainer");
    //x = x0.childNodes; // get the child divs inside the parentdiv (uploadedimagecontainer)
    //var x = document.getElementById('uploadedimagecontainer').children; //returns a HTMLCollection


    for (i = 0; i < x.length; i++) {
        var element = x[i];

        //x[i].style.visibility == 'hidden';


        var classlist = x[i].classList;
        var currentclass = classlist[1];


        if (currentclass == c) {

            alert("found a match: currentclass: " + currentclass + " c: " + c + " length: " + x.length);
            //x[i].style.display == 'inline-block';
            document.getElementById(c + "div").style.display == 'block';
            //document.getElementById(c + "div").style.visibility == 'visible';
        }
        else {
            x[i].style.display == 'none';
        }

    }
}



// Add active class to the current control button (highlight it)
//var btnContainer = document.getElementById("myBtnContainer");
//var btnContainer = document.getElementById("myBtnContainer");
//var btns = btnContainer.getElementsByClassName("imagecategorylink");
//for (var i = 0; i < btns.length; i++) {
//    btns[i].addEventListener("click", function () {
//        var current = document.getElementsByClassName("active");
//        current[0].className = current[0].className.replace(" active", "");
//        this.className += " active";
//    });
//}

//function getimagesbycategory(category)
//{
//const uploadedImageCategoryModels = document.getElementsByClassName("imagecategorylink");
//const uploadedImageCategoryModels = document.getElementsByClassName(category);
//const uploadedImageCategoryModels = document.getElementsByClassName(category);
//const testDivs = Array.prototype.filter.call(uploadedImageCategoryModels, (testElement) => testElement.nodeName === "DIV",);
//const testDivs = Array.prototype.filter.call(uploadedImageCategoryModels, (testElement) => testElement.nodeName === "DIV",);
//console.log(uploadedImageCategoryModels);
//console.log(testDivs);
//}



function showaddtextdiv(placementid) {
    document.getElementById('addtextform').placementid.value = placementid;
    document.getElementById('placementidtext').innerHTML = placementid;
    hidealladdcontentdivs();
    showdiv1('addtextdiv');
    //document.getElementById('addtextform').document.getElementById('addtextdiv').style.display = 'block';
    //document.getElementById('xxxxxxx').focus();
}

function showaddhtmldiv(placementid) {
    document.getElementById('addhtmlform').placementid.value = placementid;
    document.getElementById('placementidhtml').innerHTML = placementid;
    hidealladdcontentdivs();
    showdiv1('addhtmldiv');
    //document.getElementById('addhtmldiv').style.display = 'block';
    document.getElementById('addhtmlform').pageparttext.focus();
}

//function showaddimagediv(placementid) {
//    document.getElementById('addimageform').placementid.value = placementid;
//    hidealladdcontentdivs();
//    showdiv1('addimagediv');
//    //document.getElementById(addimagediv).style.display = 'block';
//    var imagepath = "imagepath" + placementid;
//    //document.getElementById('addimageform').imagepath.focus();

//    // set the focus on imagepath
//    //var form1 = document.getElementById('addimageform');
//    document.getElementById(imagepath).focus();
//}
function showaddimagediv(placementid) {
    //document.getElementById('addimageform').placementid.value = "1";
    //document.getElementById('placementidimage').innerHTML = "1";
    document.getElementById('addimageform').placementid.value = placementid;
    document.getElementById('placementidimage').innerHTML = placementid;
    hidealladdcontentdivs();
    showdiv1('addimagediv');
    //document.getElementById(addimagediv).style.display = 'block';
    //var imagepath = "imagepath" + placementid;
    //document.getElementById('addimageform').imagepath.focus();
    // set the focus on imagepath
    //var form1 = document.getElementById('addimageform');
    document.getElementById("imagepath1").focus();
    //alert('showaddimagediv1---' + document.getElementById('addimageform').placementid.value);
}

function showaddcateringdiv(placementid) {
    document.getElementById('addcateringform').placementid.value = placementid;
    //document.getElementById('placementidimage').innerHTML = placementid;
    hidealladdcontentdivs();
    showdiv1('addcateringdiv');
    //document.getElementById("imagepath1").focus();
}

function showaddtodayslunchdiv(placementid) {
    document.getElementById('addtodayslunchform').placementid.value = placementid;
    //document.getElementById('placementidimage').innerHTML = placementid;
    hidealladdcontentdivs();
    showdiv1('addtodayslunchdiv');
    //document.getElementById("imagepath1").focus();
}

//function showaddimagediv2() {
    
//    document.getElementById('addimageform').placementid.value = "2";
//    document.getElementById('placementidimage').innerHTML = "2";
//    hidealladdcontentdivs();
//    showdiv1('addimagediv');
//    //var imagepath = "imagepath" + placementid;
//    document.getElementById("imagepath1").focus();
//    //alert('showaddimagediv2---' + document.getElementById('addimageform').placementid.value);
//}

function hidealladdcontentdivs(placementid) {
    document.getElementById('addtextdiv').style.display = 'none';
    document.getElementById('addhtmldiv').style.display = 'none';
    document.getElementById('addimagediv').style.display = 'none';
    //document.getElementById('addcateringdiv').style.display = 'none';
    document.getElementById('addtodayslunchdiv').style.display = 'none';
}

function showdiv1(element) {
    document.getElementById(element).style.display = 'block';
}

function toggledarkmode() {
    var element = document.body;
    element.classList.toggle("dark-mode");
}




function approach1Fn(className) {
    const boxes = document.querySelectorAll('.filterdiv');
    boxes.forEach(box => {
        if (box.classList.contains(className)) {
            box.style.display = 'inline-block';
        } else {
            box.style.display = 'none';
        }
    });
}
function showFn() {
    const boxes = document.querySelectorAll('.filterdiv');
    boxes.forEach(box => {
        box.style.display = 'inline-block';
    });
}


// hide all items and only show the ones in the uncategorized category from start
approach1Fn('uncategorized');


function changeweek(week) {
    
    //week = todayslunchweek.value;
    //const week2 = week;

    //var week1 = 'todayslunchweekdiv' + (parseInt(week) + 0);
    //var week2 = 'todayslunchweekdiv' + (parseInt(week) + 1);
    //var week3 = 'todayslunchweekdiv' + (parseInt(week) + 2);
    var weekdiv = 'todayslunchweekdiv' + week;

    var week16 = 'todayslunchweekdiv16';
    var week17 = 'todayslunchweekdiv17';
    var week18 = 'todayslunchweekdiv18';
    //var week = e.options[e.selectedIndex].text;

    document.getElementById("weeknumberdiv").innerHTML = 'Vecka ' + week;

    console.log('-> ' + 'week: ' + week + ', weekdiv: ' + weekdiv);
    

    //console.log(week16);
    //console.log(week17);
    //console.log(week18);

    // hide all weeks
    //document.getElementById('week1').style.display = 'none';
    //document.getElementById('week2').style.display = 'none';
    //document.getElementById('week3').style.display = 'none';

    document.getElementById(week16).style.display = 'none';
    document.getElementById(week17).style.display = 'none';
    document.getElementById(week18).style.display = 'none';

    // show the selected week
    //if (week == '16') { document.getElementById(weekdiv).style.display = 'block'; }
    //if (week == '17') { document.getElementById(weekdiv).style.display = 'block'; }
    //if (week == '18') { document.getElementById(weekdiv).style.display = 'block'; }


    document.getElementById(weekdiv).style.display = 'block';
    //document.getElementById('todayslunchweekdiv' + week).style.display = 'block';
    //var x = document.getElementById("todayslunchweek");
    //x.value = x.value.toUpperCase();
}



function daybubble(elementtoshow, week, weekday)
{
    // set all 5 daydivs to not active
    //week16monday
    var monday = document.getElementById('week' + week + 'monday');
    monday.classList.remove("btnw2");
    monday.classList.add("btnw2");

    var tuesday = document.getElementById('week' + week + 'tuesday');
    tuesday.classList.remove("btnw2");
    tuesday.classList.add("btnw2");

    var wednesday = document.getElementById('week' + week + 'wednesday');
    wednesday.classList.remove("btnw2");
    wednesday.classList.add("btnw2");

    var thursday = document.getElementById('week' + week + 'thursday');
    thursday.classList.remove("btnw2");
    thursday.classList.add("btnw2");

    var friday = document.getElementById('week' + week + 'friday');
    friday.classList.remove("btnw2");
    friday.classList.add("btnw2");


    // todayslunchweekdiv16monday
    //document.getElementById(element).style.display = 'block';


    var el = document.getElementById(elementtoshow);
    el.classList.remove("btnw2");
    el.classList.add("btnw1");
    //el.style.display = 'block';
}

//function showweekdaydivs(elementtoshow,year,week,weekday) {
function changeweekday(elementtoshow, week, weekday)
{
    //var week = document.getElementById("todayslunchweek").options[document.getElementById("todayslunchweek").selectedIndex].value;

    console.log('-> elementtoshow ' + elementtoshow + ', week ' + week + ', weekday ' + weekday);

    // get the values of the 3 weeks in the selectbox
    var firstweek = document.getElementById("todayslunchweek")[0].value ?? "";
    var secondweek = document.getElementById("todayslunchweek")[1].value ?? "";
    var thirdweek = document.getElementById("todayslunchweek")[2].value ?? "";
    console.log('firstweek ' + firstweek + ', secondweek ' + secondweek + ', thirdweek ' + thirdweek);
    
    // get the selected value from the selectbox
    //var selectedtodayslunchweekvalue = document.getElementById("todayslunchweek").value ?? "";
    var selectedtodayslunchweekvalue = document.getElementById("todayslunchweek").options[document.getElementById("todayslunchweek").selectedIndex].value; 
    console.log('todayslunchweekvalue ' + selectedtodayslunchweekvalue);




    // hide the 3 weekday container divs. Only show the 1 we selected
    var weekdiv1 = document.getElementById("weekdiv1AAA");
    var weekdiv2 = document.getElementById("weekdiv2AAA");
    var weekdiv3 = document.getElementById("weekdiv3AAA");
    if (selectedtodayslunchweekvalue == firstweek) {
        weekdiv1.style.display = 'block';
        weekdiv2.style.display = 'none';
        weekdiv3.style.display = 'none';
    }
    else if (selectedtodayslunchweekvalue == secondweek) {
        weekdiv1.style.display = 'none';
        weekdiv2.style.display = 'block';
        weekdiv3.style.display = 'none';
    }
    else if (selectedtodayslunchweekvalue == thirdweek) {
        weekdiv1.style.display = 'none';
        weekdiv2.style.display = 'none';
        weekdiv3.style.display = 'block';
    }

    // 
    daybubble(elementtoshow, week, weekday);





    // iterate all todayslunchitem and only show "monday" items. hide the rest
    //var todayslunchitems = document.getElementsByClassName('todayslunchitem0');
    //console.log(todayslunchitems);


    const todayslunchitems = document.querySelectorAll('.todayslunchitem0');
    todayslunchitems.forEach(todayslunchitem1234 => {
        todayslunchitem1234.style.display = 'block';
        //console.log(todayslunchitem1234);
        //console.log('-------');

        //if (todayslunchitem1234.classList.contains('monday')) {
        if (todayslunchitem1234.classList.contains(weekday)) {
            //todayslunchitem1234.style.display == 'block';
            //var el2 = document.getElementById(todayslunchitem1234);
            todayslunchitem1234.style.display = 'block';
            //console.log('contains monday');
            //console.log(todayslunchitem1234);
        }
        else {
            //todayslunchitem1234.style.display == 'none';
            //var el2 = document.getElementById(todayslunchitem1234);
            todayslunchitem1234.style.display = 'none';
            //console.log('!contains monday');
            //console.log(todayslunchitem1234);
        }
    });

    //for (var todayslunchitem1234 in todayslunchitems)
    //{
    //    //console.log(todayslunchitem1234.id);
    //    if (todayslunchitem1234.className.contains('monday')) {
    //        //todayslunchitem1234.style.display == 'block';
    //        var el2 = document.getElementById(todayslunchitem1234.id);
    //        el2.style.display == 'block';
    //        console.log('lolzor');
    //        console.log(el2);
    //    }
    //    else
    //    {
    //        //todayslunchitem1234.style.display == 'none';
    //        var el2 = document.getElementById(todayslunchitem1234.id);
    //        el2.style.display == 'none';
    //    }
    //}
}