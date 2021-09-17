import React from 'react';
import { Doughnut } from 'react-chartjs-2';

export default function DoughnutChart(props: any){
    return(
        <Doughnut data={
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