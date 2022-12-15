import React, { ChangeEvent, useEffect } from "react";
import { Button, Form, Segment } from "semantic-ui-react";
import { useState } from "react";
import { useStore } from "../../../app/stores/store";
import { observer } from "mobx-react-lite";
import { Link, useNavigate, useParams } from "react-router-dom";
import { Revenue } from "../../../app/models/revenue";
import LoadingComponent from "../../../app/layout/LoadingComponent";

export default observer(function RevenueForm() {
  const { revenueStore } = useStore();

  const { createRevenue, updateRevenue, loading, loadRevenue, loadingInitial } =
    revenueStore;

  const { id } = useParams();
  const navigate = useNavigate();

  const [revenue, setRevenue] = useState<Revenue>({
    rev_Id: "",
    item_Id: "",
    rev_Desc: "",
    rev_Amount: "",
    rev_By: "",
    rev_Date: "",
    rev_Month_Year: "",
    finalized: "",
  });

  useEffect(() => {
    if (id) loadRevenue(id).then((revenue) => setRevenue(revenue!));
  }, [id, loadRevenue]);

  function handleSubmit() {
    if (!revenue.rev_Id) {
      //activity.id = uuid();
      createRevenue(revenue).then(() =>
        navigate(`/revenues/${revenue.rev_Id}`)
      );
    } else {
      updateRevenue(revenue).then(() =>
        navigate(`/revenues/${revenue.rev_Id}`)
      );
    }
    //activity.id ? updateActivity(activity) : createActivity(activity);
    //createOrEdit(activity);
  }

  function handleInputChange(
    event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) {
    const { name, value } = event.target;
    setRevenue({ ...revenue, [name]: value });
  }
  if (loadingInitial) {
    return <LoadingComponent content="loading REvenues..." />;
  }
  return (
    <Segment clearing>
      <Form onSubmit={handleSubmit} autoComplete="off">
        <Form.Input
          placeholder="Amount"
          value={revenue.rev_Amount}
          name="amount"
          onChange={handleInputChange}
        />
        { <Form.TextArea
          placeholder="Description"
          value={revenue.rev_Desc}
          name="description"
          onChange={handleInputChange}
        /> }
        <Form.Input
          placeholder="Item"
          value={revenue.item_Id}
          name="item"
          onChange={handleInputChange}
        />
        <Form.Input
          type="date"
          placeholder="Date"
          value={revenue.rev_Date}
          name="date"
          onChange={handleInputChange}
        />
        <Form.Input
          placeholder="MonthYear"
          value={revenue.rev_Month_Year}
          name="monyear"
          onChange={handleInputChange}
        />
        <Form.Input
          placeholder="Final"
          value={revenue.finalized}
          name="final"
          onChange={handleInputChange}
        />
        <Button
          loading={loading}
          floated="right"
          positive
          type="submit"
          content="Submit"
        />
        <Button
          as={Link}
          to="/revenues"
          floated="right"
          type="button"
          content="Cancel"
        />
      </Form>
    </Segment>
  );
});
