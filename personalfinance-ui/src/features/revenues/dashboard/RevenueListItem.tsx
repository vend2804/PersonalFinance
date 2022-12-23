import { format } from "date-fns";
import React from "react";
import { Link } from "react-router-dom";
import { Button, Item, Segment, Icon } from "semantic-ui-react";
//import { useStore } from "../../../app/stores/store";
import { Revenue } from '../../../app/models/revenue';

interface Props {
  revenue: Revenue;
}

export default function RevenueListItem({ revenue }: Props) {

  return (
    <Segment.Group>
        <Segment>
          <Item.Group>
              <Item>
                <Item.Image size='tiny' circular src='/assets/user.png'/>
                <Item.Content>
                    <Item.Header as={Link} to={`/revenues/${revenue.rev_Id}`}>
                      {revenue.rev_Amount}
                      </Item.Header>
                      <Item.Description>Revenue Amount</Item.Description>
                  </Item.Content>
                </Item>
            </Item.Group>
          </Segment>
          <Segment>
            <span>
              <Icon name='clock' /> {format(revenue.rev_Date!, 'dd MMM yyyy h:mm aa')}
              <Icon name='marker' /> {revenue.rev_Desc}
              </span>
            </Segment>
            <Segment secondary>
             Revenue occured by {revenue.rev_By}
             </Segment>

             <Segment clearing>
            <span>
             {revenue.rev_Desc}
             </span>
             <Button as= {Link}
             to={`/revenues/${revenue.rev_Id}`}
             color='teal'
             floated='right'
             content='view' />
            </Segment>

      </Segment.Group>

  );
}
