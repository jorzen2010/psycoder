

//copper插件的配合使用

function SkyfileCopper(ac,result) {

    switch (ac)
    {
        case "avatar":
            var token = $('[name=__RequestVerificationToken]').val();
            $.ajax({
                type: 'POST',
                url: "/File/UploadImageBase64",
                data: {
                    id: $('#CustomerId').val(),
                    img: result.toDataURL('image/jpeg'),
                    __RequestVerificationToken: token,
                    rootpath: "/FilesUpload",
                    folder: "Avatars",
                    pre: "avatar",
                },
                dataType: "json",
                success: function (data) {
                    alert('头像修改上传成功！');
                    $('#getCroppedCanvasbtn').attr('data-skyac', "");
                    $('#PsyAvatarSrc').attr('src', data.MessageUrl);
                    $('#PsyAvatar').val(data.MessageUrl);
                    $('#avatar-modal').modal('hide');
                    $('#avatarImgBtn').parent().html("<button class='btn btn-xs btn-danger' onclick='editOk(this)' data-z='PsyAvatar'>确认修改</button>");
                },
                error: function () {
                    alert("error：有错误发生了")
                }
            });
            break;

        case "IdCardSC":
            var token = $('[name=__RequestVerificationToken]').val();
            $.ajax({
                type: 'POST',
                url: "/File/UploadImgBase64",
                data: {
                    id: $('#CustomerId').val(),
                    img: result.toDataURL('image/jpeg'),
                    __RequestVerificationToken: token,
                    rootpath: "/Resource/Upload",
                    folder: "IdcardHold",
                },
                dataType: "json",
                success: function (data) {
                   
                //    $('#skyAvatar').attr('src', data.MessageUrl);
                    alert('Success：手持身份证照片上传成功');
                    $('#avatar-modal').modal('hide');
                    $('#IdCardHoldImg').attr('src', data.MessageUrl);
                    $('[name="CustomerHoldCard"]').val(data.MessageUrl);
                    $('#getCroppedCanvasbtn').attr('data-skyac', "");
                    
                },
                error: function () {
                    alert("error：有错误发生了")
                }
            });
            break;

        case "skyIdCardZM":
            var token = $('[name=__RequestVerificationToken]').val();
            $.ajax({
                type: 'POST',
                url: "/File/UploadImgBase64",
                data: {
                    id: $('#CustomerId').val(),
                    img: result.toDataURL('image/jpeg'),
                    __RequestVerificationToken: token,
                    rootpath: "/Resource/Upload",
                    folder: "Idcardzm",
                },
                dataType: "json",
                success: function (data) {
                    alert('Success：身份证正面照片上传成功');
                    //    $('#skyAvatar').attr('src', data.MessageUrl);
                    $('#IdCardZMImg').attr('src', data.MessageUrl);
                    $('#getCroppedCanvasbtn').attr('data-skyac', "");
                    $('[name="CustomerIDCardzm"]').val(data.MessageUrl);
                    $('#avatar-modal').modal('hide');
                    
                },
                error: function () {
                    alert("error：有错误发生了")
                }
            });
            break;

        case "skyIdCardFM":
            var token = $('[name=__RequestVerificationToken]').val();
            $.ajax({
                type: 'POST',
                url: "/File/UploadImgBase64",
                data: {
                    id: $('#CustomerId').val(),
                    img: result.toDataURL('image/jpeg'),
                    __RequestVerificationToken: token,
                    rootpath: "/Resource/Upload",
                    folder: "Idcardfm",
                },
                dataType: "json",
                success: function (data) {
                    alert('Success：身份证反面照片上传成功');
                    //    $('#skyAvatar').attr('src', data.MessageUrl);
                    $('#IdCardFMImg').attr('src', data.MessageUrl);
                    $('#getCroppedCanvasbtn').attr('data-skyac', "");
                    $('[name="CustomerIDCardsm"]').val(data.MessageUrl);
                    $('#avatar-modal').modal('hide');
                   
                },
                error: function () {
                    alert("error：有错误发生了")
                }
            });
            break;
        case "videoimg":
            var token = $('[name=__RequestVerificationToken]').val();
            $.ajax({
                type: 'POST',
                url: "/File/UploadImgBase64",
                data: {
                    img: result.toDataURL('image/jpeg'),
                    __RequestVerificationToken: token,
                    rootpath: "/Resource/Video",
                    folder: "photo",
                },
                dataType: "json",
                success: function (data) {
                    alertconfirm('Success：视频封面上传成功');
                    $('#videoPhoto').attr('src', data.MessageUrl);
                    $('#getCroppedCanvasbtn').attr('data-skyac', "");
                    $('[name="VideoPhoto"]').val(data.MessageUrl);
                    $('#avatar-modal').modal('hide');

                },
                error: function () {
                    alertconfirm("error：有错误发生了")
                }
            });
            break;

        case "cover":
            var token = $('[name=__RequestVerificationToken]').val();
            $.ajax({
                type: 'POST',
                url: "/File/UploadImageBase64",
                data: {
                    img: result.toDataURL('image/jpeg'),
                    __RequestVerificationToken: token,
                    rootpath: "/FilesUpload",
                    folder: "Covers",
                    pre: "covers",
                },
                dataType: "json",
                success: function (data) {
                    alertconfirm('封面上传成功');
                    $('#CoverPhoto').attr('src', data.MessageUrl);
                    $('#getCroppedCanvasbtn').attr('data-skyac', "");
                    $('[name="Cover"]').val(data.MessageUrl);
                    $('#avatar-modal').modal('hide');

                },
                error: function () {
                    alertconfirm("error：有错误发生了")
                }
            });
            break;

        case "imgAd":
            var token = $('[name=__RequestVerificationToken]').val();
            $.ajax({
                type: 'POST',
                url: "/File/UploadImageBase64",
                data: {
                    img: result.toDataURL('image/jpeg'),
                    __RequestVerificationToken: token,
                    rootpath: "/FilesUpload",
                    folder: "Advert",
                    pre:"ad",
                },
                dataType: "json",
                success: function (data) {
                    alertconfirm('图片广告上传成功');
                    $('#GuanggaoImgSrcPhoto').attr('src', data.MessageUrl);
                    $('#getCroppedCanvasbtn').attr('data-skyac', "");
                    $('[name="GuanggaoImgSrc"]').val(data.MessageUrl);
                    $('#avatar-modal').modal('hide');

                },
                error: function () {
                    alertconfirm("error：有错误发生了")
                }
            });
            break;

    }

}

