import React, { ChangeEvent } from "react";
import { Button, Form, Segment } from "semantic-ui-react";
import { useState } from "react";
import { useStore } from "../../../app/stores/store";
import { observer } from "mobx-react-lite";

export default observer(function RevenueForm() {
  const { revenueStore } = useStore();

  const { selectedRevenue, closeForm, createRevenue, updateRevenue, loading } =
    revenueStore;
  const initialState = selectedRevenue ?? {
    rev_Id: '',
    item_Id: '',
    rev_Desc: '',
    rev_Amount: '',
    rev_By: "",
    rev_Date: '',
    rev_Month_Year: "",
    finalized: "",
  };

  const [revenue, setRevenue] = useState(initialState);

  function handleSubmit() {
    revenue.rev_Id ? updateRevenue(revenue) : createRevenue(revenue);
    //createOrEdit(activity);
  }

  function handleInputChange(
    event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) {
    const { name, value } = event.target;
    setRevenue({ ...revenue, [name]: value });
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
        <Form.TextArea
          placeholder="Description"
          value={revenue.rev_Desc}
          name="description"
          onChange={handleInputChange}
        />
        <Form.Input
          placeholder="Item"
          value={revenue.item_Id}
          name="Item"
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
          placeholder="Month/Year"
          value={revenue.rev_Month_Year}
          name="monyear"
          onChange={handleInputChange}
        />
        <Form.Input
          placeholder="Final"
          value={revenue.finalized}
          name="Final"
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
          floated="right"
          type="button"
          content="Cancel"
          onClick={() => closeForm()}
        />
      </Form>
    </Segment>
  );
});
