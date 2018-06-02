

   function printContent(el) {
        var restorepage = $('body').html();
        var printcontent = $('#' + el).clone();
        $('body').empty().html(printcontent);
        window.print();
        $('body').html(restorepage);
    }

    var n = 6;
    var yData = [];
    var xData = [1, 2, 3, 4, 5, 6];
    var avg = [100, 90, 95, 88, 80, 94];

    var months = ['January', 'February', 'March', 'April', 'May', 'June'];

    function clickedStudent(student) {
        // make the calendar visible
        document.getElementById("cal").style.visibility = "visible";
        document.getElementById("timeButton").style.visibility = "visible";
        document.getElementById('head').innerHTML = student.getAttribute("value");

        // randomize points on line graph
        for (i = 0; i < n; i++) {
            yData[i] = Math.random() * 100;
        }

        var data = [];

        for (var i = 0; i < xData.length; i++) {
            var result = {
                x: xData[i],
                y: yData[i],
                type: 'scatter'
            };
            var result2 = {
                x: xData[i],
                y: avg[i],
                type: 'scatter'
            };
            data.push(result, result2);
        }

        var StudentAttendance = {
            x: xData,
            y: yData,
            type: 'scatter',
            name: 'Student Attendance'
        };
        var AverageAttendance = {
            x: xData,
            y: avg,
            type: 'scatter',
            name: 'Average Attendance'
        };
        var data = [AverageAttendance, StudentAttendance];

        var layout = {
            title: 'Student Attendance',
            xaxis: {
                title: 'Months',
                tickvals: xData,
                ticktext: months
            },
            yaxis: {
                title: 'Attendance Percentage'
            }
        };

        //plot the data for the line graph

        Plotly.newPlot('myDiv', data, layout);

        var data = [{
            values: [85, 15],
            labels: ['85%', '15%'],
            domain: {
                x: [0, .48]
            },
            name: 'Attendance',
            text: 'Attendance',
            textposition: 'inside',
            hoverinfo: 'label+percent+name',
            hole: .4,
            type: 'pie'
        }, {
            values: [25, 75],
            labels: ['25%', '75%'],
            domain: { x: [.52, 1] },
            name: 'On Time',
            text: 'On Time',
            textposition: 'inside',
            hoverinfo: 'label+percent+name',
            hole: .4,
            type: 'pie'
        }];

        var layout = {
            annotations: [
                {
                    font: {
                        size: 13
                    },
                    showarrow: false,
                    x: 0.16,
                    y: 0.5,
                    text: 'Attendance'
                },
                {
                    font: {
                        size: 13
                    },
                    showarrow: false,
                    x: 0.81,
                    y: 0.5,
                    text: 'On Time'
                }
            ]
        };
        // plot the data for the pie charts
        Plotly.newPlot('secondDiv', data, layout);
    }