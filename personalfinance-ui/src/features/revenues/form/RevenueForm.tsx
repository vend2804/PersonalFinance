import React, { useEffect } from "react";
import { Button, Form, Header, Segment } from "semantic-ui-react";
import { useState } from "react";
import { useStore } from "../../../app/stores/store";
import { observer } from "mobx-react-lite";
import { Link, useNavigate, useParams } from "react-router-dom";
import { Revenue } from "../../../app/models/revenue";
import LoadingComponent from "../../../app/layout/LoadingComponent";
import { Formik } from "formik";
import * as Yup from "yup";
import MyTextInput from "../../../app/common/form/MyTextInput";
import MyTextArea from "../../../app/common/form/MyTextArea";
import MyDateInput from "../../../app/common/form/MyDateInput";
import MySelectInput from "../../../app/common/form/MySelectInput";
import { finalizedOptions } from "../../../app/common/options/finalizedOptions";
import { itemdOptions } from '../../../app/common/options/itemOptions';

export default observer(function RevenueForm() {
  const { revenueStore } = useStore();

  const { createRevenue, updateRevenue, loading, loadRevenue, loadingInitial } =
    revenueStore;

  const { id } = useParams();
  const navigate = useNavigate();

  const [revenue, setRevenue] = useState<Revenue>({
    rev_Id: 0,
    item_Id: 1,
    rev_Desc: "",
    rev_Amount: "",
    rev_By: "1",
    rev_Date: null,
    rev_Month_Year: "",
    finalized: true,
  });

  const validationSchema = Yup.object({
    rev_Amount: Yup.string().required("The revenue amount is required!"),
    rev_Desc: Yup.string().required("The revenue description is required!"),
    item_Id: Yup.string().required(),
    rev_Date: Yup.string().required("Date is Required").nullable(),
    rev_Month_Year: Yup.string().required(),
    finalized: Yup.string().required(),
    //category: Yup.string().required(),
  });

  useEffect(() => {
    if (id) loadRevenue(id).then((revenue) => setRevenue(revenue!));
  }, [id, loadRevenue]);

  function handleFormSubmit(revenue: Revenue) {
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

  if (loadingInitial) {
    return <LoadingComponent content="loading Revenues..." />;
  }
  return (
    <Segment clearing>
      <Header content="Activity Details" sub color="teal" />
      <Formik
        validationSchema={validationSchema}
        initialValues={revenue}
        enableReinitialize
        onSubmit={(values) => handleFormSubmit(values)}
      >
        {({ handleSubmit, isValid, isSubmitting, dirty }) => (
          <Form className="ui form" onSubmit={handleSubmit} autoComplete="off">
            <MyTextInput placeholder="Amount" name="rev_Amount" label="" />
            <MyTextArea
              rows={3}
              placeholder="Description"
              name="rev_Desc"
              label=""
            />
            <MySelectInput
              options={itemdOptions}
              placeholder="Item"
              name="item_Id"
              label=""
          />
         {/*    <MyTextInput placeholder="Item" name="item_Id" label="" /> */}

            <MyDateInput
              placeholderText="Date"
              showTimeSelect
              timeCaption="time"
              dateFormat="MMMM d, yyyy h:mm aa"
              name="rev_Date"
            />
            <Header content="Rev Details" sub color="teal" />
            <MyTextInput
              placeholder="MonthYear"
              name="rev_Month_Year"
              label=""
            />
            <MySelectInput
              options={finalizedOptions}
              placeholder="Finalized"
              name="finalized"
              label=""
            />
            {/* <MyTextInput placeholder="Finalized" name="finalized" label="" /> */}
            <Button
              disabled={isSubmitting || !isValid || !dirty}
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
        )}
      </Formik>
    </Segment>
  );
});
