import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Card from '@material-ui/core/Card';
import CardContent from '@material-ui/core/CardContent';
import Typography from '@material-ui/core/Typography';

const useStyles = makeStyles({
  root: {
    minWidth: 280,
    maxWidth: 280,
    minHeight: 375,
    maxHeight: 375,
  },
  bullet: {
    display: 'inline-block',
    margin: '0 2px',
    transform: 'scale(0.8)',
  },
  title: {
    fontSize: 14,
  },
  pos: {
    marginBottom: 12,
  },
});

export default function ChartCard(props: { title: boolean | React.ReactChild | React.ReactFragment | React.ReactPortal | null | undefined; description?: boolean | React.ReactChild | React.ReactFragment | React.ReactPortal | null | undefined; statistic?: boolean | React.ReactChild | React.ReactFragment | React.ReactPortal | null | undefined; chart?: boolean | React.ReactChild | React.ReactFragment | React.ReactPortal | null | undefined; }){
  const classes = useStyles();
  return(
  <Card className={classes.root} variant="outlined">
    <CardContent>
      <Typography className={classes.title} color="textSecondary" gutterBottom>
        {props.title}
      </Typography>
      <Typography className={classes.pos} color="textSecondary">
        {props.description}
      </Typography>
      <Typography variant="h5" component="h2">
        {props.statistic}
      </Typography>
      <Typography >
        {props.chart}
      </Typography>
    </CardContent>
  </Card>
  );
}
