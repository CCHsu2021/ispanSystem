
//-----------------------------Create---------------------------------------------

// 判斷Checkbox
var currentSelect = 0, limit = 1;
function doCheck(obj) {
    obj.checked ? currentSelect++ : currentSelect--;
    if (currentSelect > limit) {
        obj.checked = false;
        Swal.fire("超過正確答案上限");
        currentSelect--;
    }
}

// 根據題型判斷答案輸入欄位及許可正確選項上限
$('#FQuestionTypeId').change(function () {
    if ($(this).val() === "3") {
        console.log("OK");
        $('#BtnNewChoice').hide();
        $('#ansList > #choice > label').html("答案");
        $('#ansList div:not(:first-child)').remove();
        $('#ansList > #choice > #checkBox1').hide();
    } else if ($(this).val() === "2") {
        limit = 100;
        $('#BtnNewChoice').show();
        $('#ansList > #choice > label').html("選項");
        $('#ansList > #choice > #checkBox1').show();
    } else if ($(this).val() === "1") {
        limit = 1;
        $('#BtnNewChoice').show();
        $('#ansList > #choice > label').html("選項");
        $('#ansList > #choice > input').removeAttr("checked");
        $('#ansList > #choice > #checkBox1').show();
    }
})

// 新增選項textbox
var count = 1;
const btnNewChoice = document.querySelector('#BtnNewChoice');
btnNewChoice.addEventListener('click', function () {
    count++;
    //var divChoice = "<div class=form-group id=choice c><label asp -for= FChoice class= control-label>選項" + count + "</label ><input id=txtAns asp-for=FChoice class=form-control /><span asp-validation-for=FChoice class=text-danger></span><button class=btn id=del-btn type=button><i class=fasfa-trash-alt> </i>Delete</button></div>"
    var divChoice = `<div class="form-group" id="choice" ><label asp -for="FChoice" class="control-label">選項</label ><br /><input type="checkbox" name="FCorrectAnswer" value=1 onclick="doCheck(this)" style="margin:0 3px 0 0;" /><input id="txtAns" asp-for="FChoice" class="form-control"/><span asp-validation-for="FChoice" class="text-danger"></span><button class="btn" id="del-btn" type="button" style="margin:10px 0 0 25px"><i class="fasfa-trash-alt"> </i>Delete</button></div>`
    $('#ansList').append(divChoice);
})
$("#outdiv").on("click", "#del-btn", function () {
    console.log("delete");
    $(this).closest("#choice").remove();
});

// 將所有選項存入Array
$('#createNew').click(function () {
    var ansArr = [];
    var selectAns = $('#ansList input[type=checkbox]:checked').length;
    if (selectAns < 1) {
        Swal.fire("請選擇此題正確答案");
    } else {
        $('#ansList > div').each(function (idx, item) {
            var ans = {}
            var c = $(item).find(':checkbox').prop('checked');
            ans.FCorrect = c ? 1 : 2;
            ans.Fchoice = $(item).find(':text').val();
            ansArr.push(ans);
        })
        console.log(ansArr);
        var jsondata = JSON.stringify({
            FSubjectId: $('#FSubjectId').val(),
            FQuestion: $('#FQuestion').val(),
            FQuestionTypeId: $('#FQuestionTypeId').val(),
            FChoiceList: ansArr,
            FLevel: $('#FLevel').val()
        })
        $.ajax({
            url: "/QuestionBank/Create",
            type: "POST",
            contentType: "application/json",
            data: jsondata
            }).done(function (data) {
                Swal.fire({
                    icon: 'success',
                    title: '新增成功',
                    showConfirmButton: true,
                    timer: 1500
                })
            })
            }
        })

//-------------------------------------------Create End--------------------------------