import React from 'react';
import { Pie } from 'react-chartjs-2';

export default function PieChart(props: any){
    return(
        <Pie data={
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