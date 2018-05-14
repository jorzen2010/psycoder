$(".menulist h4").mouseover(function () {
    $(this).css("background-color", "#eeeeee");
}).mouseout(function () {
    $(this).css("background-color", "#f7f8fa");
});
$(".menulist ul li").mouseover(function () {
    $(this).css("background-color", "#eeeeee");
}).mouseout(function () {
    $(this).css("background-color", "#f7f8fa");
});


//register的表单验证

$('#jibenxinxi').bootstrapValidator({
    live: 'enabled',
    submitButtons: '#btn-test',
    message: 'This value is not valid',
    feedbackIcons: {
        valid: 'glyphicon glyphicon-ok',
        invalid: 'glyphicon glyphicon-remove',
        validating: 'glyphicon glyphicon-refresh'
    },
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
    submitButtons: '#btn-test',
    message: 'This value is not valid',
    feedbackIcons: {
        valid: 'glyphicon glyphicon-ok',
        invalid: 'glyphicon glyphicon-remove',
        validating: 'glyphicon glyphicon-refresh'
    },
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
