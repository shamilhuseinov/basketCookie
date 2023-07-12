jQuery(function ($) {
    $(document).on('click', '#addtocart', function () {
        var id = $(this).data('id');
        $.ajax({
            method: "GET",
            url: "/basket/add",
            data: {
                id:id
            },
            success: function (res) {
                alert(res)
            }
            error: function (err) {
                alert(err.responseText)
            }
            })
    })

    $(document).on('click', '#increaseCount', function (e) {
        e.preventDefault();
        var increaseCount = $(this);
        var id = $(this).data('id');
        $.ajax({
            method: "GET",
            url: "/basket/increaseCount",
            data: {
                id: id
            },
            success: function (res) {
                var count = $(increaseCount).parent().siblings()[3].html();
                count++;
                $(increaseCount).parent().siblings()[3].html(count);
            }
            error: function (err) {
                alert(err.responseText)
            }
        })
    })

    $(document).on('click', '#decreaseCount', function (e) {
        e.preventDefault();
        var decreaseCount = $(this);
        var id = $(this).data('id');
        $.ajax({
            method: "GET",
            url: "/basket/decreaseCount",
            data: {
                id: id
            },
            success: function (res) {
                var count = $(decreaseCount).parent().siblings()[3].html();
                count--;
                $(decreaseCount).parent().siblings()[3].html(count);
            }
            error: function (err) {
                alert(err.responseText)
            }
        })
    })
})