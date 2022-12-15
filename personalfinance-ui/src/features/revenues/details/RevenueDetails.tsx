import React, { useEffect } from "react";
import { Link, useParams } from "react-router-dom";
import { Card, Image, Button } from "semantic-ui-react";
import LoadingComponent from "../../../app/layout/LoadingComponent";
import { useStore } from "../../../app/stores/store";

export default function RevenueDetails() {
  const { revenueStore } = useStore();
  const {
    selectedRevenue: revenue,
    loadRevenue,
    loadingInitial,
  } = revenueStore;

  const { id } = useParams();

  useEffect(() => {
    if (id) loadRevenue(id);
  }, [id, loadRevenue]);

  if (loadingInitial || !revenue) return <LoadingComponent />;
  return (
    <Card fluid>
      <Image src={`/assets/categoryImages/${revenue?.rev_By}.jpg`} />
      <Card.Content>
        <Card.Header>{revenue.rev_Amount}</Card.Header>
        <Card.Meta>
          <span>{revenue.rev_Date}</span>
        </Card.Meta>
        <Card.Description>{revenue.rev_Desc}</Card.Description>
      </Card.Content>
      <Card.Content extra>
        <Button.Group widths="2">
          <Button
            as={Link}
            to={`/managerevenues/${revenue.rev_Id}`}
            basic
            color="blue"
            content="Edit"
          />
          <Button
            as={Link}
            to="/revenues"
            basic
            color="grey"
            content="Cancel"
          />
        </Button.Group>
      </Card.Content>
    </Card>
  );
}
