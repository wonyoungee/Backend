function EmpList(ID) {   // 데이터 조회
    $.ajax(
        {
            url: "/Home/EmpList/" + ID,
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