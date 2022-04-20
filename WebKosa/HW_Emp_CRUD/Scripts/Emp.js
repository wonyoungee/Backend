$(document).ready(function () {
    loadData();
});

function loadData() {   // 데이터 조회
    $.ajax(
        {
            url: "/Home/List",
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                console.log(result);
                let html = "";
                $.each(result, function (index, item) {
                    html += "<tr>";
                    html += "<td>" + item.empno + "</td>";
                    html += "<td>" + item.ename + "</td>";
                    html += "<td>" + item.job + "</td>";
                    html += "<td>" + item.mgr + "</td>";
                    html += "<td>" + item.hiredate + "</td>";
                    html += "<td>" + item.sal + "</td>";
                    html += "<td>" + item.comm + "</td>";
                    html += "<td>" + item.deptno + "</td>";
                    html += '<td><a href="#" onclick="return getbyID(' + item.empno + ')">Edit</a> | <a href="#" onclick="Delete(' + item.empno + ')">Delete</a></td>';
                    html += "</tr>";
                });
                $('.tbody').html(html);
            },
            error: function (errmsg) {
                alert(errmsg.responseText);
            }
        }
    );
}

function getbyID(ID) {
    $.ajax(
        {
            url: "/Home/GetbyID/" + ID,      // Home/GetbyID/1    가능     >>  RouteConfig에 url: "{controller}/{action}/{id}" 로 돼있으므로..
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                //console.log(result);
                $('#Empno').val(result.empno);
                $('#Ename').val(result.ename);
                $('#Job').val(result.job);
                $('#Mgr').val(result.mgr);
                $('#Hiredate').val(result.hiredate);
                $('#Sal').val(result.sal);
                $('#Comm').val(result.comm);
                $('#Deptno').val(result.deptno);

                $('#myModal').modal('show');
                $('#btnUpdate').show();
                $('#btnAdd').hide();
            },
            error: function (errmsg) {
                alert(errmsg.responseText);
            }

        }
    );
}


function Add() {

    let empobj = {
        empno: $('#Empno').val(),
        ename: $('#Ename').val(),
        job: $('#Job').val(),
        mgr: $('#Mgr').val(),
        hiredate: $('#Hiredate').val(),
        sal: $('#Sal').val(),
        comm: $('#Comm').val(),
        deptno: $('#Deptno').val()
    };
    console.log(empobj);
    $.ajax(
        {
            url: "/Home/Add",   // 서버쪽에 요청
            data: JSON.stringify(empobj),    // HomeController의 Add()가 받음
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                loadData(); // 다시 비동기 조회 함수 호출
                $('#myModal').modal('hide');
            },
            error: function (errmsg) {
                alert(errmsg.responseText);
            }
        }
    );
}

function Update() {

    let empobj = {
        empno: $('#Empno').val(),
        ename: $('#Ename').val(),
        job: $('#Job').val(),
        mgr: $('#Mgr').val(),
        hiredate: $('#Hiredate').val(),
        sal: $('#Sal').val(),
        comm: $('#Comm').val(),
        deptno: $('#Deptno').val()
    };

    $.ajax(
        {
            url: "/Home/Update",   // 서버쪽에 요청
            data: JSON.stringify(empobj),    // HomeController의 Update()가 받음
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                loadData(); // 다시 비동기 조회 함수 호출
                $('#myModal').modal('hide');
                $('#Empno').attr("disabled", true);
                $('#Empno').val("");
                $('#Ename').val("");
                $('#Job').val("");
                $('#Mgr').val("");
                $('#Hiredate').val("");
                $('#Sal').val("");
                $('#Comm').val("");
                $('#Deptno').val("");
            },
            error: function (errmsg) {
                alert(errmsg.responseText);
            }
        }
    );
}

function Delete(ID) {
    let answer = confirm("정말 삭제하시겠습니까?");
    if (answer) {
        $.ajax(
            {
                url: "/Home/Delete/" + ID,   // 서버쪽에 요청
                type: 'POST',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    loadData(); // 다시 비동기 조회 함수 호출
                },
                error: function (errmsg) {
                    alert(errmsg.responseText);
                }
            }
        );
    }
}

function clearTextBox() {
    $('#Empno').attr("disabled", false);
    $('#Empno').val("");
    $('#Ename').val("");
    $('#Job').val("");
    $('#Mgr').val("");
    $('#Hiredate').val("");
    $('#Sal').val("");
    $('#Comm').val("");
    $('#Deptno').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#Ename').css('border-color', 'lightgrey');
    $('#Job').css('border-color', 'lightgrey');
    $('#Mgr').css('border-color', 'lightgrey');
    $('#Hiredate').css('border-color', 'lightgrey');
    $('#Sal').css('border-color', 'lightgrey');
    $('#Comm').css('border-color', 'lightgrey');
    $('#Deptno').css('border-color', 'lightgrey');
}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#Ename').val().trim() == "") {
        $('#Ename').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Ename').css('border-color', 'lightgrey');
    }
    if ($('#Job').val().trim() == "") {
        $('#Job').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Job').css('border-color', 'lightgrey');
    }
    if ($('#Mgr').val().trim() == "") {
        $('#Mgr').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Mgr').css('border-color', 'lightgrey');
    }
    if ($('#Hiredate').val().trim() == "") {
        $('#Hiredate').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Hiredate').css('border-color', 'lightgrey');
}
if ($('#Sal').val().trim() == "") {
        $('#Sal').css('border-color', 'Red');
isValid = false;
    }
    else {
    $('#Sal').css('border-color', 'lightgrey');
}
if ($('#Comm').val().trim() == "") {
        $('#Comm').css('border-color', 'Red');
isValid = false;
    }
    else {
    $('#Comm').css('border-color', 'lightgrey');
}
if ($('#Deptno').val().trim() == "") {
        $('#Deptno').css('border-color', 'Red');
isValid = false;
    }
    else {
    $('#Deptno').css('border-color', 'lightgrey');
}
    return isValid;
}