import React, { SyntheticEvent } from "react";
import { Item, Segment, Button, Label } from "semantic-ui-react";

import { useState } from "react";
import { useStore } from "../../../app/stores/store";
import { observer } from "mobx-react-lite";
import { Link } from "react-router-dom";

export default observer(function RevenueList() {
  const { revenueStore } = useStore();

  const { deleteRevenue, revenuesByDate, loading } = revenueStore;
  const [target, setTarget] = useState("");

  function handleRevenueDelete(
    e: SyntheticEvent<HTMLButtonElement>,
    id: string
  ) {
    setTarget(e.currentTarget.name);
    deleteRevenue(id);
  }

  return (
    <Segment>
      <Item.Group divided>
        {revenuesByDate.map((revenue) => (
          <Item key={revenue.rev_Id}>
            <Item.Content>
              <Item.Header as="a">{revenue.rev_Amount}</Item.Header>
              <Item.Meta>{revenue.rev_Date}</Item.Meta>
              <Item.Description>
                <div>{revenue.rev_Desc}</div>
                <div>
                  {revenue.rev_Month_Year}, {revenue.rev_Id}
                </div>
              </Item.Description>
              <Item.Extra>
                <Button
                  as={Link}
                  to={`/revenues/${revenue.rev_Id}`}
                  floated="right"
                  content="view"
                  color="blue"
                />
                <Button
                  name={revenue.rev_Id}
                  loading={loading && target === revenue.rev_Id}
                  onClick={(e) => handleRevenueDelete(e, revenue.rev_Id)}
                  floated="right"
                  content="delete"
                  color="red"
                />
                <Label basic content={revenue.rev_By} />
              </Item.Extra>
            </Item.Content>
          </Item>
        ))}
      </Item.Group>
    </Segment>
  );
});
