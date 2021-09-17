import React from 'react';
import { PolarArea } from 'react-chartjs-2';

export default function PolarChart(props: any){
    return(
        <PolarArea data={
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