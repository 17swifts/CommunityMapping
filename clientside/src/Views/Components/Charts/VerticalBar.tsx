import React from 'react';
import { Bar } from 'react-chartjs-2';

const options = {
  scales: {
    yAxes: [
      {
        ticks: {
          beginAtZero: true,
        },
      },
    ],
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
        }}
      />
    );
}