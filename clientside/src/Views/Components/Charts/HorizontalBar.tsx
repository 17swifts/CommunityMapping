import React from 'react';
import { Bar } from 'react-chartjs-2';

const options = {
    indexAxis: 'y',
    // Elements options apply to all of the options unless overridden in a dataset
    // In this case, we are setting the border of each horizontal bar to be 2px wide
    elements: {
      bar: {
        borderWidth: 2,
      },
    },
    responsive: true,
    plugins: {
      legend: {
        position: 'right',
      },
    },
  };

export default function VerticalBar(props : any){
    return(
        <Bar data={
          {
            labels: props.labels,
            datasets: [
              {
                label: props.label,
                data: props.data,
                backgroundColor: props.backgroundColor,
                borderWidth: 1,
              },
            ],
        }} />
    );
}