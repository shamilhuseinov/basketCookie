
jQuery(document).ready(function ($) {

    
    $(document).on('click', '#tab-title-description', function () {
        $('#tab-description').css("display", "block");
        $("#tab-additional_information").css("display", "none");
        $(this).addClass('active');
        $("#tab-title-additional_information").removeClass('active');
    })

    $(document).on('click', '#tab-title-additional_information', function () {
        $("#tab-additional_information").css("display", "block");
        $('#tab-description').css("display", "none");
        $(this).addClass('active');
        $("#tab-title-description").removeClass('active');
    })

    var skipRow = 1;
    $(document).on('click', '#Tural', function () {
        console.log("salam")
        $.ajax({
            method: "GET",
            url: "/product/loadmore",
            data: {
                skipRow: skipRow

            },
            success: function (result) {
                console.log(result)
                $('#avara').append(result);
                skipRow++
            },
            error: function (e) {
                console.log(e)
            }
        })

    })
});


