import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Card from '@material-ui/core/Card';
import CardContent from '@material-ui/core/CardContent';
import Typography from '@material-ui/core/Typography';

const useStyles = makeStyles({
  root: {
    minWidth: 320,
    maxWidth: 320,
    minHeight: 400,
    maxHeight: 400,
  },
  smallcard: {
    minWidth: 330,
    maxWidth: 330,
    minHeight: 400,
    maxHeight: 400,
  },
  largecard:{
    minWidth: 670,
    maxWidth: 670,
    minHeight: 700,
    maxHeight: 700,
  },
  tallcard: {
    minWidth: 330,
    maxWidth: 330,
    minHeight: 700,
    maxHeight: 700,
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

export default function ChartCard(props: { title: boolean | React.ReactChild | React.ReactFragment | React.ReactPortal | null | undefined; description?: boolean | React.ReactChild | React.ReactFragment | React.ReactPortal | null | undefined; statistic?: boolean | React.ReactChild | React.ReactFragment | React.ReactPortal | null | undefined; chart?: boolean | React.ReactChild | React.ReactFragment | React.ReactPortal | null | undefined; cardstyle: boolean | React.ReactChild | React.ReactFragment | React.ReactPortal | null | undefined; }){
  const classes = useStyles();
  var cardClass;
  if(props.cardstyle === "small") {
    cardClass = classes.smallcard;
  } else if(props.cardstyle === "large") {
    cardClass = classes.largecard;
  } else if(props.cardstyle === "tall") {
    cardClass = classes.tallcard;
  }
  return(
  <Card className={cardClass} variant="outlined">
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
