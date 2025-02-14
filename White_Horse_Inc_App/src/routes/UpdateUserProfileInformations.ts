import { UPDATE_USER_INFORMATIONS } from "@/utils/backEndUrls/urls";
import GetHeader from "./GetRequestHeader";
import { UserInformations } from "@/@types/req";



export async function fetchUpdateUserProfile( userInfo: UserInformations ): Promise<UserInformations> {

  var response: any = await fetch(UPDATE_USER_INFORMATIONS, {
    method: "PUT",
    headers: GetHeader(),
    body: JSON.stringify(userInfo),
  });

  const data: Promise<UserInformations> = await response.json();
  return data;
}
