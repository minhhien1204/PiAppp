var user = {
    init: function () {
        user.allEvents();
    },

    allEvents: function () {//tat ca su kien
        $('.btn-light').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var username = $(btn).data("username");
            $.ajax({
                url: "/Admin/User/ChangeStatus",
                data: { username: username },
                type: "POST",
                dataType: "json",
                success: function (response)
                {
                    console.log(response);
                    if (response.status == true)
                    {
                        btn.text("Hoạt Động");
                    
                    }
                    else
                    {
                        btn.text("Khóa");
                    }  
                }
            });
        });
    }
}
user.init();
