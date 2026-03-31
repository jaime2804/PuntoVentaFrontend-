// Set new default font family and font color to mimic Bootstrap's default styling
Chart.defaults.global.defaultFontFamily = 'Nunito', '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
Chart.defaults.global.defaultFontColor = '#858796';


// Bar Chart Example
let controlVenta = document.getElementById("charVentas");
let myBarChart = new Chart(controlVenta, {
  type: 'bar',
  data: {
      labels: ["06/01/2024", "07/01/2024", "08/01/2024", "09/02/2024", "10/02/2024", "11/03/2024", "12/03/2024"],
    datasets: [{
      label: "Cantidad",
        backgroundColor: "#f28705",
        hoverBackgroundColor: "#F2B705",
        borderColor: "#f28705",
      data: [12,10,22,11,15,10,22],
    }],
  },
  options: {
    maintainAspectRatio: false,
    legend: {
      display: false
    },
    scales: {
      xAxes: [{
        gridLines: {
          display: false,
          drawBorder: false
        },
        maxBarThickness: 50,
      }],
      yAxes: [{
        ticks: {
          min: 0,
          maxTicksLimit: 5
        }
      }],
    },
  }
});
