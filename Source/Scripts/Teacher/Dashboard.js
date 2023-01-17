$(document).ready(function () {
    fetchCourses();
    fetchEvalPeriods();

    var ctx = document.getElementById('classDataChart');
    var myChart = new Chart(ctx, {
        type: 'pie',
        data: {
            labels: ['Below', 'Basic', 'Proficient', 'Advanced', 'Advanced+'],
            datasets: [{
                data: [0, 0, 0, 0, 0],
                backgroundColor: [
                    'rgba(190, 73, 22, 0.3)',
                    'rgba(235, 174, 38, 0.3)',
                    'rgba(18, 114, 58, 0.3)',
                    'rgba(108, 169, 176, 0.3)',
                    'rgba(30, 95, 139, 0.3)'
                ],
                borderColor: [
                    'rgba(190, 73, 22, 1)',
                    'rgba(235, 174, 38, 1)',
                    'rgba(18, 114, 58, 1)',
                    'rgba(108, 169, 176, 1)',
                    'rgba(30, 95, 139, 1)'
                ],
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false
        }
    });

    $("#chartEval").change(function () {
        var classId = $("#chartClass").val();
        var evalPeriod = $("#chartEval").val();
        if (classId <= 0 || evalPeriod <= 0) {
            // do nothing
            return;
        }
        else {
            fetchChartData(myChart, classId, evalPeriod);
        }
    });

    $("#chartClass").change(function () {
        var classId = $("#chartClass").val();
        var evalPeriod = $("#chartEval").val();
        if (classId <= 0 || evalPeriod <= 0) {
            // do nothing
            return;
        }
        else {
            fetchChartData(myChart, classId, evalPeriod);
        }
    });
});


function fetchChartData(chart, classID, EvalID) {
    $.ajax({
        type: "GET",
        url: "/Teacher/GetChartData",
        data: {
            courseID: classID,
            evalPeriod: EvalID
        },
        success: function (data) {
            for (var x = 0; x < data.length; x++) {
                chart.data.datasets[0].data[x] = data[x];
            }
            chart.update();
        },
        error: function (error) {
            alert(error);
        }
    });
};
 

function fetchCourses() {
    var YearId = $("#CurrentYear").val();
    $.ajax({
        type: "GET",
        url: "/Teacher/GetClassesByTeacherIDandYearID",
        data: { YearID: YearId },
        success: function (data) {
            var optionHTML = '<option value="-1">Please Select a Course</option>';
            for (var i = 0; i < data.length; i++) {
                if (data[i].IsDefault) {
                    DefaultSelected = true;
                    optionHTML += '<option value="' + data[i].ID + '" selected>' + data[i].CourseTitle + '</option>';
                }
                else {
                    optionHTML += '<option value="' + data[i].ID + '">' + data[i].CourseTitle + '</option>';

                }
            }
            $("#classDropdown").html(optionHTML);
            $("#chartClass").html(optionHTML);
        },
        error: function (error) {
            alert(error);
        }
    });
}

function fetchEvalPeriods() {
    $.ajax({
        type: "GET",
        url: "/Teacher/GetEvalPeriods",
        success: function (data) {
            var optionHTML = '<option value="-1">Please Select a Month</option>';
            for (let item of data) {
                optionHTML += '<option value="' + item.ID + '">' + item.evalDescription + '</option>';
            }
            $("#chartEval").html(optionHTML);
        },
        error: function (error) {
            alert(error);
        }
    });
}
