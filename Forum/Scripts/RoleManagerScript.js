/// <reference path="jquery-2.1.3.js" />

$('#roleCommit').click(function () {
    $.post(
        '/Admin/ManageRoles',
        'UserName=' + $('#userSelect option:selected').val() + '&NewRole=' + $('#roleSelect option:selected').val(),
        function (data) {
            if (data)
                alert('User role updated');
            else
                alert('Update failed');
        }
    );
});