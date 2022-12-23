import { format } from "date-fns";
import { observer } from "mobx-react-lite";
import React from "react";
import { Link } from "react-router-dom";
import { Button, Header, Item, Segment, Image } from "semantic-ui-react";
import { Revenue } from '../../../app/models/revenue';

const activityImageStyle = {
  filter: "brightness(30%)",
};

const revenueImageTextStyle = {
  position: "absolute",
  bottom: "5%",
  left: "5%",
  width: "100%",
  height: "auto",
  color: "white",
};

interface Props {
  revenue: Revenue;
}

export default observer(function RevenueDetailedHeader({ revenue }: Props) {
  return (
    <Segment.Group>
      <Segment basic attached="top" style={{ padding: "0" }}>
        <Image
          src={`/assets/categoryImages/${revenue.rev_Id}.jpg`}
          fluid
          style={activityImageStyle}
        />
        <Segment style={revenueImageTextStyle} basic>
          <Item.Group>
            <Item>
              <Item.Content>
                <Header
                  size="huge"
                  content={revenue.rev_Amount}
                  style={{ color: "white" }}
                />
                <p>{format(revenue.rev_Date!, 'dd MMM yyyy ')}</p>
                <p>
                  revenue by <strong>Vendim</strong>
                </p>
              </Item.Content>
            </Item>
          </Item.Group>
        </Segment>
      </Segment>
      <Segment clearing attached="bottom">
        <Button color="teal">Create Revenue</Button>
        <Button>Cancel Revenue</Button>
        <Button as={Link} to={`/managerevenues/${revenue.rev_Id}`} color="orange" floated="right">
          Manage Revenues
        </Button>
      </Segment>
    </Segment.Group>
  );
});
