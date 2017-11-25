var Id = 0;
var upc = 0;

function Add() {
    var MAX = 'Maximum Files: No Limit';
    var DivFiles = document.getElementById('pnlFiles');
    var DivListBox = document.getElementById('pnlListBox');
    var BtnAdd = document.getElementById('btnAdd');

    var IpFile = GetTopFile();
    if (IpFile == null || IpFile.value == null || IpFile.value.length == 0) {
        alert('Please select a file to add.');
        return;
    }

    var NewIpFile = CreateFile();
    DivFiles.insertBefore(NewIpFile, IpFile);
    if (MAX != 0 && GetTotalFiles() - 1 == MAX) {
        NewIpFile.disabled = true;
        BtnAdd.disabled = true;
    }
    IpFile.style.display = 'none';
    DivListBox.appendChild(CreateItem(IpFile));
}

function CreateFile() {
    var IpFile = document.createElement('input');
    IpFile.id = IpFile.name = 'IpFile_' + Id++;
    IpFile.type = 'file';
    return IpFile;
}

function CreateItem(IpFile) {
    var MAX = 'Maximum Files: No Limit';
    var DivFiles = document.getElementById('pnlFiles');
    var DivListBox = document.getElementById('pnlListBox');
    var BtnAdd = document.getElementById('btnAdd');

    var Item = document.createElement('div');
    Item.style.backgroundColor = '#ffffff';
    Item.style.fontWeight = 'normal';
    Item.style.textAlign = 'left';
    Item.style.verticalAlign = 'middle';
    Item.style.cursor = 'default';
    Item.style.height = 20 + 'px';
    var Splits = IpFile.value.split('\\\\');
    Item.innerHTML = Splits[Splits.length - 1] + '&nbsp;';
    Item.value = IpFile.id;
    Item.title = IpFile.value;
    var A = document.createElement('a');
    A.innerHTML = 'Delete';
    A.id = 'A_' + Id++;
    A.style.color = 'blue';
    A.onclick = function () {
        //DivFiles.removeChild(document.getElementById(this.parentNode.value));
        DivListBox.removeChild(this.parentNode);
        if (MAX != 0 && GetTotalFiles() - 1 < MAX) {
            GetTopFile().disabled = false;
            BtnAdd.disabled = false;
        }
    }
    Item.appendChild(A);
    Item.onmouseover = function () {
        Item.bgColor = Item.style.backgroundColor;
        Item.fColor = Item.style.color;
        Item.style.backgroundColor = '#C6790B';
        Item.style.color = '#ffffff';
        Item.style.fontWeight = 'bold';
    }
    Item.onmouseout = function () {
        Item.style.backgroundColor = Item.bgColor;
        Item.style.color = Item.fColor;
        Item.style.fontWeight = 'normal';
    }
    return Item;
}

function Clear() {
    var MAX = 'Maximum Files: No Limit';
    var DivFiles = document.getElementById('pnlFiles');
    var DivListBox = document.getElementById('pnlListBox');
    var BtnAdd = document.getElementById('btnAdd');

    DivListBox.innerHTML = '';
    DivFiles.innerHTML = '';
    DivFiles.appendChild(CreateFile());
    BtnAdd.disabled = false;
}

function GetTopFile() {
    var MAX = 'Maximum Files: No Limit';
    var DivFiles = document.getElementById('pnlFiles');
    var DivListBox = document.getElementById('pnlListBox');
    var BtnAdd = document.getElementById('btnAdd');

    var Inputs = DivFiles.getElementsByTagName('input');
    var IpFile = null;
    for (var n = 0; n < Inputs.length && Inputs[n].type == 'file'; ++n) {
        IpFile = Inputs[n];
        break;
    }
    return IpFile;
}

function GetTotalFiles() {
    var MAX = 'Maximum Files: No Limit';
    var DivFiles = document.getElementById('pnlFiles');
    var DivListBox = document.getElementById('pnlListBox');
    var BtnAdd = document.getElementById('btnAdd');

    var Inputs = DivFiles.getElementsByTagName('input');
    var Counter = 0;
    for (var n = 0; n < Inputs.length && Inputs[n].type == 'file'; ++n)
        Counter++;
    return Counter;
}

function GetTotalItems() {
    
    var MAX = 'Maximum Files: No Limit';
    var DivFiles = document.getElementById('pnlFiles');
    var DivListBox = document.getElementById('pnlListBox');
    var BtnAdd = document.getElementById('btnAdd');

    var Items = DivListBox.getElementsByTagName('div');
    return Items.length;
}

function DisableTop() {
    var MAX = 'Maximum Files: No Limit';
    var DivFiles = document.getElementById('pnlFiles');
    var DivListBox = document.getElementById('pnlListBox');
    var BtnAdd = document.getElementById('btnAdd');

    if (GetTotalItems() == 0) {
        alert('Please browse at least one file to upload.');
        return false;
    }
    GetTopFile().disabled = true;
    return true;
}














//var nowTemp = new Date();
//var now = new Date(nowTemp.getFullYear(), nowTemp.getMonth(), nowTemp.getDate(), 0, 0, 0, 0);
//var files;
//var storedFiles = [];
//var upc = 0;

//$(function () {

//    $(":file").attr('title', '  ');
//    var $loading = $('#loadingDiv').hide();

//    $("input[id^='fileToUpload']").change(function (e) {
//        doReCreate(e);
//    });

//    selDiv = $("#selectedFiles");
//});

function doReCreate(e) {
    upc = upc + 1;

    $("input[id^='file']").hide();

    $('<input>').attr({
        type: 'file',
        multiple: 'multiple',
        id: 'file' + upc,
        name: 'file',
        style: 'float: left',
        title: '  ',
        onchange: "doReCreate(event)"

    }).appendTo('#pnlFiles');
}

//function handleFileSelect(e) {

//    //selDiv.innerHTML = ""; storedFiles = []; 
//    selDiv = document.querySelector("#selectedFiles");

//    if (!e.target.files) return;

//    //selDiv.innerHTML = "";
//    files = e.target.files;

//    for (var i = 0; i < files.length; i++) {
//        //if (i == 0) { selDiv.innerHTML = ""; storedFiles = []; }
//        var f = files[i];
//        selDiv.innerHTML += "<div>" + f.name +
//        "<a onclick='removeAtt(this)'> X </a></div>";
//        storedFiles.push(f.name);
//    }
//    $('#@Html.IdFor(i => i.FilesToBeUploaded)').val(storedFiles);
//}

//function removeAtt(t) {
//    var serEle = $(t).parent().text().slice(0, -3);
//    var index = storedFiles.indexOf(serEle);
//    if (index !== -1) {
//        storedFiles.splice(index, 1);
//    }
//    $(t).parent().remove();

//    $('#@Html.IdFor(i => i.FilesToBeUploaded)').val(storedFiles);

//}