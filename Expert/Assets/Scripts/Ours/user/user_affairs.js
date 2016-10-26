var hub=null;
function register_user(name,family,password,mobile,username){
    hub.server.registerUser(name, family, password, mobile, username).done(function (result) {
        if (result) {
            alert("you have been registered!");
            $("#sms_vccode").attr("href", "sms://+14035550185?body=I%27m%20interested%20in%20your%20product.%20Please%20contact%20me.");
            $.mobile.changePage("#pagev", { transition: "slideup" });
            getVerificationCode();
            
            var scope = $("#verification_win").scope();
            scope.$apply(function () {
                scope.start_timer();
            });
           
        } else {
            alert("already done with this user name!");
        }
    });

}
function TryAgainVerify() {
    getVerificationCode();

    var scope = $("#verification_win").scope();
    scope.$apply(function () {
       scope.counter_show = true;
        scope.start_timer();
    });
}
function getVerificationCode() {
    hub.server.getVerificationCode().done(function (result) {
        var scope = $("#verification_win").scope();
        scope.$apply(function () {
            $scope.timer_val = 10;
            scope.verificationCode=result;
        });
    });
    
}
function check_username_availablity( username) {
    hub.server.checkUserNameAvailablity(username).done(function (result) {
        if (result) {
            alert("yes,you can");
        } else {
            alert("no,sorry!");
        }
    });

}
$(function () {
    hub = $.connection.sysetemHub;
   
    
   
    hub.client.showAppFace = function (type, message) {
        
        switch (type) {

            case 1:
              
                document.getElementById('successAudio').play();
                $(':mobile-pagecontainer').pagecontainer('change', '#pageSuccess');
                break;
            case 2:
              

                $(':mobile-pagecontainer').pagecontainer('change', '#pageVerify');
                break;
        };
    };
   
    $.connection.hub.start().done(function () {
        $('#btn_login').click(function () {
            hub.server.send("!", "1");

        });
    });
});