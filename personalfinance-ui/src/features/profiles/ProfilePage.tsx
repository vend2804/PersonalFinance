import { observer } from "mobx-react-lite";
import React from "react";
import { Grid } from "semantic-ui-react";
import ProfileContent from "./ProfileContent";
import ProfileHeader from "./ProfileHeader";
import { useParams } from "react-router-dom";
import { useStore } from "../../app/stores/store";
import { useEffect } from "react";
import LoadingComponent from "../../app/layout/LoadingComponent";

export default observer(function ProfilePage() {
  //const{username} =  useParams();
  const { username } = useParams<{ username: string }>();
  const { profileStore } = useStore();
  const { loadingProfile, loadProfile, profile } = profileStore;

  // in order to use the load Profile method we will use useEffect hook;

  useEffect(() => {
    if (username) loadProfile(username);
  }, [loadProfile, username]);

  if (loadingProfile) return <LoadingComponent content="Loading profile ..." />;

  return (
    <Grid>
      <Grid.Column width={16}>
        {
        profile  &&
        <>
        <ProfileHeader profile={profile} />

        <ProfileContent profile={profile} />
       </> }

      </Grid.Column>
    </Grid>
  );
});
