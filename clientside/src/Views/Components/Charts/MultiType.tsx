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
                type: props.type1,
                label: props.label1,
                data: props.data1,
                backgroundColor: props.backgroundColor,
                borderWidth: 1,
              },
              {
                type: props.type2,
                label: props.label2,
                borderColor: props.borderColor,
                borderWidth: 2,
                fill: false,
                data: props.data2,
              },
            ],
        }} />
    );
}