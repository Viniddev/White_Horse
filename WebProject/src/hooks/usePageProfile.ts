import { UserInformations, UpdateUserInformations } from "@/@types/req";
import { fetchPutRequest } from "@/routes/FetchPutRequest";
import { GET_USER_INFORMATIONS, UPDATE_USER_INFORMATIONS } from "@/utils/backEndUrls/urls";
import { EMPTY_USER } from "@/utils/constants/consts";
import { Toast } from "primereact/toast";
import React, { FormEvent, useRef } from "react";

export default function usePageProfile() {
  const toast = useRef<Toast>(null);
  const [userData, setUserData] = React.useState<UserInformations>(EMPTY_USER);

  async function GetUserInformations() {
    let localUserInfo: string = sessionStorage.getItem("UserInfo") ?? "";

    if (localUserInfo == "") {
      let email: string = sessionStorage.getItem("Sub") ?? "";
      if(email === "")
        return;

      let userInfo: any = await fetchPutRequest({Email: email}, GET_USER_INFORMATIONS);

        if(!userInfo.data){
          toast?.current?.show({
            severity: "error",
            summary: "Info",
            detail: userInfo.message,
            life: 3500,
          }); 
          return;
        }
        return userInfo.data;
    } else {
      let UserInfo: UserInformations = JSON.parse(localUserInfo);
      return UserInfo;
    }
  }

  async function UpdateUserInformations(e: FormEvent<HTMLFormElement>) {
    e.preventDefault();

    const updateInformations: UpdateUserInformations = {
      id: userData.id,
      role: userData.role,
      email: userData.email,
      phoneNumber: userData.phoneNumber,
      address: userData.address,
    };

    let userInfo: any = await fetchPutRequest(updateInformations, UPDATE_USER_INFORMATIONS);
    
    if(!userInfo.data){
      toast?.current?.show({
        severity: "error",
        summary: "Info",
        detail: userInfo.message,
        life: 3500,
      }); 
      return;
    }else{
      toast?.current?.show({
        severity: "info",
        summary: "Info",
        detail: userInfo.message,
        life: 3500,
      });
    }
    
    sessionStorage.removeItem("UserInfo");
    GetUserInformations();
    return userInfo.data;
  }

  React.useEffect(() => {
    const fetchData = async () => {
      let userInfo: UserInformations = await GetUserInformations();

      if (userInfo)
        sessionStorage.setItem("UserInfo", JSON.stringify(userInfo));

      setUserData(userInfo);
    };

    fetchData();
  }, []);

  return {
    GetUserInformations,
    UpdateUserInformations,
    userData,
    setUserData,
    toast,
  };
}
