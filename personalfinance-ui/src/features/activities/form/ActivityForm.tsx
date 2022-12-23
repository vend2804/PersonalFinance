import React from "react";
import { Button, Header, Segment } from "semantic-ui-react";
import { useState } from "react";
import { useStore } from "../../../app/stores/store";
import { observer } from "mobx-react-lite";
import { Link, useNavigate, useParams } from "react-router-dom";
import { useEffect } from "react";
import { Activity } from "../../../app/models/activity";
import LoadingComponent from "../../../app/layout/LoadingComponent";
import { v4 as uuid } from "uuid";
import { Formik, Form } from "formik";
import * as Yup from "yup";
import MyTextInput from "../../../app/common/form/MyTextInput";
import MyTextArea from "../../../app/common/form/MyTextArea";
import MySelectInput from "../../../app/common/form/MySelectInput";
import { categoryOptions } from "../../../app/common/options/categoryOptions";
import MyDateInput from "../../../app/common/form/MyDateInput";

export default observer(function ActivityForm() {
  const { activityStore } = useStore();

  const {
    createActivity,
    updateActivity,
    loading,
    loadActivity,
    loadingInitial,
  } = activityStore;

  const { id } = useParams();
  const navigate = useNavigate();

  const [activity, setActivity] = useState<Activity>({
    id: "",
    title: "",
    category: "",
    description: "",
    date: null,
    city: "",
    venue: "",
  });

  const validationSchema = Yup.object({
    title: Yup.string().required("The activity title is required!"),
    description: Yup.string().required("The activity description is required!"),
    category: Yup.string().required(),
    date: Yup.string().required('Date is Required').nullable(),
    venue: Yup.string().required(),
    city: Yup.string().required(),
    //category: Yup.string().required(),
  });

  useEffect(() => {
    if (id) loadActivity(id).then((activity) => setActivity(activity!));
  }, [id, loadActivity]);

  function handleFormSubmit(activity: Activity) {
    if (!activity.id) {
      activity.id = uuid();
      createActivity(activity).then(() =>
        navigate(`/activities/${activity.id}`)
      );
    } else {
      updateActivity(activity).then(() =>
        navigate(`/activities/${activity.id}`)
      );
    }
    //activity.id ? updateActivity(activity) : createActivity(activity);
    //createOrEdit(activity);
  }

  if (loadingInitial) {
    return <LoadingComponent content="loading Activity..." />;
  }
  return (
    <Segment clearing>
      <Header content="Activity Details" sub color="teal" />
      <Formik
        validationSchema={validationSchema}
        initialValues={activity}
        enableReinitialize
        onSubmit={(values) => handleFormSubmit(values)}
      >
        {({ handleSubmit, isValid, isSubmitting, dirty }) => (
          <Form className="ui form" onSubmit={handleSubmit} autoComplete="off">
            <MyTextInput name="title" placeholder="Title" label="" />
            <MyTextArea
              rows={3}
              placeholder="Description"
              name="description"
              label=""
            />
            <MySelectInput
              options={categoryOptions}
              placeholder="Category"
              name="category"
              label=""
            />
            <MyDateInput
              placeholderText="Date"
              showTimeSelect
              timeCaption="time"
              dateFormat="MMMM d, yyyy h:mm aa"
              name="date"
            />
            <Header content="Location Details" sub color="teal" />
            <MyTextInput placeholder="City" name="city" label="" />
            <MyTextInput placeholder="Venue" name="venue" label="" />
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
              to="/activities"
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
