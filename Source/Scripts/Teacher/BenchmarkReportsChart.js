$('#evalDropdown').on('change', function () {
    var yearid = $('#academicYearDropdown').val();
    var courseid = $('#classDropdown').val();
    var evalperiod = $('#evalDropdown').val();
    var ctx = document.getElementById('ClassChart').getContext('2d');

    var classChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: ['Below Basic', 'Basic', 'Proficient', 'Advanced', 'Advanced +'],
            datasets: [{
                label: 'Students',
                data: [0, 0, 0, 0, 0],
                backgroundColor: [
                    'rgba(190, 73, 22, 0.2)',
                    'rgba(235, 174, 38, 0.2)',
                    'rgba(18, 114, 58, 0.2)',
                    'rgba(30, 95, 139, 0.2)'
                ],
                borderColor: [
                    'rgba(190, 73, 22, 1)',
                    'rgba(235, 174, 38, 1)',
                    'rgba(18, 114, 58, 1)',
                    'rgba(30, 95, 139, 1)'
                ],
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });
    GetBenchmarkData(yearid, courseid, evalperiod);
    GetChartData(classChart, yearid, courseid, evalperiod);

    document.getElementById('contentPanel').style.display = 'block';
    document.getElementById('ChartPanel').style.display = 'block';
});

function GetChartData(chart, yearid, courseid, evalperiod) {
    $.ajax({
        type: "GET",
        url: "/Evaluation/GetChartDataBenchmark",
        dataType: "JSON",
        data: {
            CourseID: courseid,
            EvalPeriod: evalperiod,
            YearID: yearid
        },
        success: function (data) {
            for (var x = 0; x < data.length; x++) {
                chart.data.datasets[0].data[x] = data[x];                
            }
            chart.update();
        },
        error: function (error) {
            alert('Error: ' + error);
        }
    });
};

function GetBenchmarkData(yearid, courseid, evalperiod) {
    $.ajax({
        type: "GET",
        url: "/Evaluation/GetBenchmarkData",
        dataType: "JSON",
        data: {
            CourseID: courseid,
            EvalPeriod: evalperiod,
            YearID: yearid
        },
        success: function (data) {
            ResetHtml();
            data.forEach(function (item) {
                $('#placeholder' + item.ProficiencyID).remove();
                $('#' + item.ProficiencyID).append('<li class="list-group-item">' + item.firstName + ' ' + item.lastName + '</li>')
            });
        },
        error: function (error) {
            alert('Error: ' + error);
        }
    });
};

function ResetHtml() {
    for (var x = 1; x < 6; x++) {
        $('#' + x).html('<li class="list-group-item text-danger" id="placeholder' + x + '">No Students Found</li>')
    }
};

