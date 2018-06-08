$(document).ready(function () {

    //初始化一个
    goStep(1);

    //register的表单验证

    $('#jibenxinxi').bootstrapValidator({
        live: 'enabled',
        // submitButtons: '#btn-test',
        message: 'This value is not valid',
        //feedbackIcons: {
        //    valid: 'glyphicon glyphicon-ok',
        //    invalid: 'glyphicon glyphicon-remove',
        //    validating: 'glyphicon glyphicon-refresh'
        //},
        fields: {
            PsyUserEmail: {
                validators: {
                    notEmpty: {
                        message: '用户名不能为空'
                    },
                    stringLength: {
                        min: 6,
                        max: 20,
                        message: '用户名长度必须在6到30之间'
                    },
                    remote: {
                        url: '/PsyUser/CheckPsyUserEmail',
                        message: '此邮箱已经被注册',
                        delay: 2000,
                        type:'POST'
                        
                    },
                }
            },
            PsyPassword: {
                validators: {
                    notEmpty: {
                        message: '密码不能为空'
                    },
                    stringLength: {
                        min: 6,
                        max: 12,
                        message: '密码长度在6到12位'
                    },
                    regexp: {
                        regexp: /^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]{6,20})$/,
                        message: '用户名需要同时包含字母和数字。'
                    },
                }
            },
            PsyPasswordConfirm: {
                validators: {
                    notEmpty: {
                        message: '重复密码也不能为空'
                    },
                    identical: {
                        field: 'PsyPassword',
                        message: '两次输入密码不一致'
                    }
                }
            },
            EmailSendCode: {
                validators: {
                    notEmpty: {
                        message: '发送的验证码不能为空'
                    },
                    stringLength: {
                        min: 6,
                        max: 6,
                        message: '发送的验证码应为六位'
                    },
                }
            },
            EmailCode: {
                validators: {
                    notEmpty: {
                        message: '验证码不能为空'
                    },
                    stringLength: {
                        min: 6,
                        max: 6,
                        message: '验证码应为六位'
                    },
                    identical: {
                        field: 'EmailSendCode',
                        message: '邮箱验证码不正确'
                    },
                }
            },
            IfGree: {
                validators: {
                    notEmpty: {
                        message: '请认真阅读此协议，并点击同意'
                    }
                }
            },

        }
    });

    $('#shenfenrenzheng').bootstrapValidator({
        live: 'enabled',
        // submitButtons: '#btn-test',
        message: 'This value is not valid',
        //feedbackIcons: {
        //    valid: 'glyphicon glyphicon-ok',
        //    invalid: 'glyphicon glyphicon-remove',
        //    validating: 'glyphicon glyphicon-refresh'
        //},
        fields: {
            PsyRealName: {
                validators: {
                    notEmpty: {
                        message: '真实姓名不能为空'
                    },
                }
            },
            PsyNumber: {
                validators: {
                    notEmpty: {
                        message: '身份证号不能为空'
                    },
                    stringLength: {
                        min: 15,
                        max: 18,
                        message: '身份证号长度为15位或18位'
                    },
                    threshold: 18,
                    remote: {
                        url: '/PsyUser/CheckPsyUserNubmer',
                        message: '身份证校验失败，请填写正确的身份证号码',
                        delay: 2000,
                        type: 'POST'

                    },
                }
            },
            PsyZhengshuNumber: {
                validators: {
                    notEmpty: {
                        message: '咨询师证书编号不能为空'
                    },
                }
            },


        }
    });

    $('#lianxifangshi').bootstrapValidator({
        live: 'enabled',
        //  submitButtons: '#btn-test',
        message: 'This value is not valid',
        //feedbackIcons: {
        //    valid: 'glyphicon glyphicon-ok',
        //    invalid: 'glyphicon glyphicon-remove',
        //    validating: 'glyphicon glyphicon-refresh'
        //},
        fields: {
            Email: {
                validators: {
                    notEmpty: {
                        message: '邮箱不能为空'
                    },
                }
            },
            QQ: {
                validators: {
                    notEmpty: {
                        message: 'QQ不能为空'
                    },
                }
            },
            Wechat: {
                validators: {
                    notEmpty: {
                        message: '微信号不能为空'
                    }
                }
            },
            Telephone: {
                validators: {
                    notEmpty: {
                        message: '手机号不能为空'
                    },
                    stringLength: {
                        min: 11,
                        max: 11,
                        message: '手机号长度为11位'
                    },
                    regexp: {
                        regexp: /^1\d{10}$/,
                        message: '手机号格式不对。'
                    },
                }
            },

        }
    });
    $('#pinpai').bootstrapValidator({
        live: 'enabled',
        //  submitButtons: '#btn-test',
        message: 'This value is not valid',
        //feedbackIcons: {
        //    valid: 'glyphicon glyphicon-ok',
        //    invalid: 'glyphicon glyphicon-remove',
        //    validating: 'glyphicon glyphicon-refresh'
        //},
        fields: {
            PsyTitle: {
                validators: {
                    notEmpty: {
                        message: '品牌名称不能为空'
                    },
                }
            },
            PsyInfo: {
                validators: {
                    notEmpty: {
                        message: '一句话介绍不能为空'
                    },
                }
            },

        }
    });


});

function NextStep(step) {
    if (step == 2) {
        $("#jibenxinxi").bootstrapValidator('validate');//提交验证  
        if ($("#jibenxinxi").data('bootstrapValidator').isValid()) {//获取验证结果，如果成功，执行下面代码  
            // alert("验证成功");//验证成功后的操作，如ajax  
            // goStep(2);
            var PsyUserEmail = $("[name='PsyUserEmail']").val();
            var PsyPassword = $("[name='PsyPassword']").val();
            var PsyPasswordCode = $("[name='PsyPasswordCode']").val();
            var PsyPasswordConfirm = $("[name='PsyPasswordConfirm']").val();
            var token = $('[name=__RequestVerificationToken]').val();
            var PsyAvatar = $("[name='PsyAvatar']").val();

            $.ajax({
                type: 'POST',
                url: "/PsyUser/RegisterJibenxinxi",
                data: {
                    PsyAvatar: PsyAvatar,
                    PsyUserEmail: PsyUserEmail,
                    PsyPassword: PsyPassword,
                    __RequestVerificationToken: token,
                    PsyStatus: "false",
                },
                dataType: "json",
                success: function (data) {
                    if (data.MessageStatus) {

                        goStep(2);
                        $("[name='UserEmail']").attr("value", PsyUserEmail);
                       // alert(data.MessageInfo);
                    }
                    else {
                        alert("操作失败，请检查输入是否正确！");
                    }

                }
            });

        }
        else {
            alert("验证失败");
        }
    }
    else if (step == 3) {
        $("#shenfenrenzheng").bootstrapValidator('validate');//提交验证  
        if ($("#shenfenrenzheng").data('bootstrapValidator').isValid()) {//获取验证结果，如果成功，执行下面代码  
            // alert("验证成功");//验证成功后的操作，如ajax  
            // goStep(2);
            var UserEmail = $("[name='UserEmail']").val();
            var PsyRealName = $("[name='PsyRealName']").val();
            var PsyNumber = $("[name='PsyNumber']").val();
            var PsyZhengshuNumber = $("[name='PsyZhengshuNumber']").val();
            var token = $('[name=__RequestVerificationToken]').val();

            $.ajax({
                type: 'POST',
                url: "/PsyUser/RegisterShenfen",
                data: {
                    UserEmail: UserEmail,
                    PsyRealName: PsyRealName,
                    PsyNumber: PsyNumber,
                    PsyZhengshuNumber: PsyZhengshuNumber,
                    __RequestVerificationToken: token,

                },
                dataType: "json",
                success: function (data) {
                    if (data.MessageStatus) {

                        goStep(step);
                      //  alert(data.MessageInfo);
                    }
                    else {
                        alert("操作失败，请检查输入是否正确！");
                    }

                }
            });

        }
        else {
            // alert("验证失败");
        }
    }
    else if (step == 4) {
        $("#lianxifangshi").bootstrapValidator('validate');//提交验证  
        if ($("#lianxifangshi").data('bootstrapValidator').isValid()) {//获取验证结果，如果成功，执行下面代码  
            // alert("验证成功");//验证成功后的操作，如ajax  
            // goStep(2);
            var UserEmail = $("[name='UserEmail']").val();
            var QQ = $("[name='QQ']").val();
            var Telephone = $("[name='Telephone']").val();
            var Wechat = $("[name='Wechat']").val();
            var Email = $("[name='Email']").val();
            var token = $('[name=__RequestVerificationToken]').val();

            $.ajax({
                type: 'POST',
                url: "/PsyUser/RegisterLianxi",
                data: {
                    UserEmail: UserEmail,
                    QQ: QQ,
                    Telephone: Telephone,
                    Wechat: Wechat,
                    Email: Email,
                    __RequestVerificationToken: token,

                },
                dataType: "json",
                success: function (data) {
                    if (data.MessageStatus) {

                        goStep(step);
                      //  alert(data.MessageInfo);
                    }
                    else {
                        alert("操作失败，请检查输入是否正确！");
                    }

                }
            });
        }
        else {
            // alert("验证失败");
        }
    }
    else if (step == 5) {
        $("#pinpai").bootstrapValidator('validate');//提交验证  
        if ($("#pinpai").data('bootstrapValidator').isValid()) {//获取验证结果，如果成功，执行下面代码  
            // alert("验证成功");//验证成功后的操作，如ajax  
            // goStep(2);
            var UserEmail = $("[name='UserEmail']").val();
            var PsyTitle = $("[name='PsyTitle']").val();
            var PsyInfo = $("[name='PsyInfo']").val();
            var PsyContent = $("[name='PsyContent']").val();
            var PsyShanchang = $("[name='PsyShanchang']").val();
            var token = $('[name=__RequestVerificationToken]').val();

            $.ajax({
                type: 'POST',
                url: "/PsyUser/RegisterPinpai",
                data: {
                    PsyTitle: PsyTitle,
                    UserEmail: UserEmail,
                    PsyInfo: PsyInfo,
                    PsyContent: PsyContent,
                    Wechat: Wechat,
                    PsyShanchang: PsyShanchang,
                    __RequestVerificationToken: token,

                },
                dataType: "json",
                success: function (data) {
                    if (data.MessageStatus) {

                        goStep(step);
                     //   alert(data.MessageInfo);
                    }
                    else {
                        alert("操作失败，请检查输入是否正确！");
                    }

                }
            });
        }
        else {
            // alert("验证失败");
        }
    }

}


function goStep(step) {
    bsStep(step);
    $(".step-content-item").hide();
    $("#step-content").find("li").eq(step - 1).show();
}

