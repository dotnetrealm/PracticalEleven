$(document).ready(() => {
    $("#CreateUser").on("click", (e) => {
        var url = 'TestTwo/Create';
        $("#UserForm").load(url);
    });

    $("#CreateUserFormBtn").on("click", (e) => {
        console.log(e);
        debugger;
        e.preventDefault();
        console.log($(this).serialize());
    });

    Array.from($(".editUser")).forEach((ele) => {
        $(ele).on("click", (e) => {
            var url = 'TestTwo/Edit/' + e.currentTarget.id;
            $("#UserForm").load(url);
        })
    })
})