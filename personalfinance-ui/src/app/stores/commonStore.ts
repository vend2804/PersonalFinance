import { ServerError } from "../models/serverError";
import { makeAutoObservable, reaction } from "mobx";
export default class CommonStore {
  error: ServerError | null = null;
  token: string | null = localStorage.getItem("jwt");
  appLoaded: boolean = false;

  constructor() {
    makeAutoObservable(this);
    // using Reaction from MobX
    // reaction happens when the user does something. login to app for example
    reaction(
      () => this.token,
      (token) => {
        if (token) {
          localStorage.setItem('jwt', token)
        }
        else {
          localStorage.removeItem('jwt')
        }
      }
    );
  }

  setServerError(error: ServerError) {
    this.error = error;
  }
  setToken = (token: string | null) => {
   // if (token) localStorage.setItem("jwt", token);
    this.token = token;
  };
  setAppLoaded = () => {
    this.appLoaded = true;
  };
}
