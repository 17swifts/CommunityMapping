import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Card from '@material-ui/core/Card';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';
import { RegionalAreaEntity } from 'Models/Entities';

const useStyles = makeStyles({
  root: {
    minWidth: 275,
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
  <Card className={classes.root}>
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

function SimpleCard() {
  const classes = useStyles();
  const bull = <span className={classes.bullet}>•</span>;

  return (
    <Card className={classes.root}>
      <CardContent>
        <Typography className={classes.title} color="textSecondary" gutterBottom>
          Word of the Day
        </Typography>
        <Typography variant="h5" component="h2">
          be{bull}nev{bull}o{bull}lent
        </Typography>
        <Typography className={classes.pos} color="textSecondary">
          adjective
        </Typography>
        <Typography variant="body2" component="p">
          well meaning and kindly.
          <br />
          {'"a benevolent smile"'}
        </Typography>
      </CardContent>
      <CardActions>
        <Button size="small">Learn More</Button>
      </CardActions>
    </Card>
  );
}
