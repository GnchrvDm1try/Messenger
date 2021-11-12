$('#send').click(function (e) {
    e.preventDefault();
    let value = $('.input').val();
    let time = new Date();
    if (value === "") {
        alert("Введите сообщение!");
    }
    else {
        $('.message__spot').append("<div class='message__content' style='margin-left: auto'><div class='time__wrapper'><p><time>" + time.getDate() + ":" + (time.getMonth() + 1) + ":" + time.getFullYear() + " " + time.getHours() + ":" + time.getMinutes() + ":" + time.getSeconds() + "</time></p></div>" + "<p>" + value + "</p></div>");
        CallSendMessage();
        $('.input').val("");
    }
});

function CallSendMessage() {
    let s1 = $('#chatuser').val();
    let s2 = $('#username').val();
    let s3 = $('.input').val();
    $.get("/Home/SendMessage/?reciever=" + s1 + "&sender=" + s2 + "&content=" + s3, function () { });
}

$('#smile').click(function () {
    let value = "<img class='emoji__img' src='/Content/Images/Emoji/smile__emoji.svg'>";
    $('.message__spot').append("<div class='message__content' style='margin-left: auto'>" + value + "</div>");
    let param = 'smileemoji';
});

$('#rage').click(function () {
    let value = "<img class='emoji__img' src='/Content/Images/Emoji/rage__emoji.svg'>";
    $('.message__spot').append("<div class='message__content' style='margin-left: auto'>" + value + "</div>");
    let param = 'rageemoji';
});

$('#settings').click(function () {
    $('.settings__wrapper').slideToggle(300);
});

$('#submit').click(function () {
    let value = $('.settings__color').val();
    $('.header__inner').css({
        "background-color": value,
    });
    $('.settings__wrapper').css({
        "background-color": value,
    });
    $('.chat__img>img').css({
        "border": "2px solid " + value,
    });
    $('.input').css({
        "border": "1px solid " + value,
    });
});

$('#dark').click(function () {
    $('body').css({
        "background-color": "#000000",
    });
    $('.chats').css({
        "background-color": "#818281",
    });
    $('.username').css({
        "color": "#ffffff",
    });
    $('.message').css({
        "color": "#ffffff",
    });
    $('.info__spot').css({
        "background-color": "#818281",
    });
    $('.info__spot-name').css({
        "color": "#ffffff",
    });
    $('.message__wrapper').css({
        "background-color": "#818281",
    });
    $('.message__content').css({
        "border": "1px solid #ffffff",
        "color": "#ffffff",
    });
    $('.time__wrapper').css({
        "color": "#ffffff",
    });
    $('.input__spot').css({
        "background-color": "#818281",
    });
    $('.btn').css({
        "background-color": "#818281",
    });
});

$('#light').click(function () {
    $('body').css({
        "background-color": "#ffffff",
    });
    $('.chats').css({
        "background-color": "#ffffff",
    });
    $('.username').css({
        "color": "#000000",
    });
    $('.message').css({
        "color": "#000000",
    });
    $('.info__spot').css({
        "background-color": "#ffffff",
    });
    $('.info__spot-name').css({
        "color": "#000000",
    });
    $('.message__wrapper').css({
        "background-color": "#ffffff",
    });
    $('.message__content').css({
        "border": "1px solid #000000",
        "color": "#000000",
    });
    $('.time__wrapper').css({
        "color": "#000000",
    });
    $('.input__spot').css({
        "background-color": "#ffffff",
    });
    $('.btn').css({
        "background-color": "#ffffff",
    });
});

$('#emoji').click(function () {
    $('.emoji__spot').slideToggle(300);
    return false;
});

$('.open__popup').click(function (e) {
    e.preventDefault();
    $('.popup__bg').fadeIn(600);
});

$('.close__popup').click(function () {
    $('.popup__bg').fadeOut(600);
});

//@* <script>
//    $(".btn").click(function (e) {

//        e.preventDefault();
//            $.ajax({

//        url: $(this).attr("href"), // comma here instead of semicolon
//                success: function () {
//        // or any other indication if you want to show
//    }

//            });

//        });
//    </script> *@