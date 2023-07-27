

(() => {
    console.log("Hola")

    const apiUrl = '/api/GetStatisticsLastMonth';

    fetch(apiUrl)
        .then(response => response.json())
        .then(data => {

           // console.log(data);
            'use strict'

            // Graphs
            const ctx = document.getElementById('myChart')
            // eslint-disable-next-line no-unused-vars
            const myChart = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: [
                        'Sunday',
                        'Monday',
                        'Tuesday',
                        'Wednesday',
                        'Thursday',
                        'Friday',
                        'Saturday'
                    ],
                    datasets: [{
                        data: [
                            data.Sunday,
                            data.Monday,
                            data.Tuesday,
                            data.Wednesday,
                            data.Thursday,
                            data.Friday,
                            data.Saturday
                        ],
                        lineTension: 0,
                        backgroundColor: 'transparent',
                        borderColor: '#007bff',
                        borderWidth: 4,
                        pointBackgroundColor: '#007bff'
                    }]
                },
                options: {
                    plugins: {
                        legend: {
                            display: false
                        },
                        tooltip: {
                            boxPadding: 3
                        }
                    },
                    scales: {
                        y: {
                            beginAtZero: true // Comenzar el eje y desde 0
                        }
                    }
                }
            })
        })
        .catch(error => {
            console.error('Error:', error);
        });

})()
