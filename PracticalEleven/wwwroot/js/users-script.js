$(document).ready(() => {

    const noUserCheck = () => {
        if ($("#UserTable tbody > tr").length == 0) {
            var data = "<tr id='NoUserFound'><td colspan='5' class='h4'><i class='fa fa-id-card'></i> User record not found</td></tr>";
            $("#UserTable tbody").html(data);
        } else {
            $("#UserTable tbody #NoUserFound").remove();
        }
    }

    const createTableRow = (user) => {
        return `<tr id="` + user.id + `">
                    <th scope="row">`+ user.id + `</th>
                                    <td>`+ user.name + `</td>
                            <td>`+ user.dob + `</td>
                    <td>`+ user.address + `</td>
                    <td>
                        <div class="d-flex justify-content-center">
                            <a class="btn btn-sm "><i class="fa fa-eye"></i></a>
                            <button class="btn btn-sm editUser z-index-3"><i class="fa fa-user-pen"></i></button>
                            <form method="post" >
                            <button type="submit" class="btn btn-sm" onclick="return confirm('Are you sure you want to delete this?')">
                                <i class="fa fa-trash"></i>
                            </button>
                        </form>
                        </div>
                    </td>
                </tr>`
    }

    const makeToast = (message) => {
        var url = 'Toast/Index?message=' + encodeURIComponent(message);
        $.get(url, (res) => {
            $("#ToastDisplay").html(res);
            $('.toast').toast('show');
        })
    }

    $("#CreateUser").on("click", (e) => {
        $("#UserForm").load("TestTwo/Create", () => {
            $("#CreateUserForm").on("submit", (e) => {
                e.preventDefault();
                $.ajax({
                    url: "TestTwo/Create",
                    type: "post",
                    data: $("#CreateUserForm").serialize(),
                    success: (res) => {
                        if (res.result == "OK") {
                            var row = createTableRow(res.data.user);
                            $("#UserTable tbody").append(row);
                            $("#UserForm").empty();
                            makeToast("User Created successfully");
                            noUserCheck();
                        }
                        else {
                            $("#ValidationSummary").removeClass("d-none");
                            $("#ValidationSummary").text(res.message);
                            //Generate toast
                            makeToast(res.message);
                        }
                    },
                })
            });
        });
    });

    Array.from($(".editUser")).forEach((ele) => {
        $(ele).on("click", (event) => {
            var url = 'TestTwo/Edit/' + event.target.closest("tr").id;
            console.log(url);
            $("#UserForm").load(url, () => {
                $("#EditUserForm").on("submit", (e) => {
                    e.preventDefault();
                    $.ajax({
                        url,
                        type: "post",
                        data: $("#EditUserForm").serialize(),
                        success: (res) => {
                            if (res.result == "OK") {
                                var row = createTableRow(res.data.user);
                                $("#" + res.data.user.id).remove();
                                $(e).parent("tr").remove();
                                $("#UserTable tbody").append(row);
                                $("#UserForm").empty();
                                makeToast("User updated successfully");
                            }
                            else {
                                $("#ValidationSummary").removeClass("d-none");
                                $("#ValidationSummary").text(res.message);
                                //Generate toast
                                makeToast(res.message);
                            }
                        },
                    })
                })
            });
        })
    })

    Array.from($(".viewUser")).forEach((ele) => {
        $(ele).on("click", (event) => {
            var url = 'TestTwo/UserDetails/' + event.target.closest("tr").id;
            $("#UserForm").load(url);
        })
    })

    Array.from($(".deleteUser")).forEach((ele) => {
        $(ele).on("click", (event) => {
            if (confirm('Are you sure you want to delete this?')) {
                var userId = event.target.closest("tr").id;
                var url = 'TestTwo/Delete/' + userId;
                $.ajax({
                    url,
                    type: "post",
                    data: { id: userId },
                    success: (res) => {
                        if (res.result == "OK") {
                            $("#" + userId).remove();
                            $("#UserForm").empty();
                            makeToast("User deleted successfully");
                            noUserCheck();
                        }
                    },
                })
            }
        })
    })

    noUserCheck();

})