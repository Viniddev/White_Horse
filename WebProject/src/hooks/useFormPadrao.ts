import { UserInformations } from "@/@types/req";
import React from "react";

export default function UseFormPadrao(DefaultUserInformations: UserInformations) {
  const isFirstRender = React.useRef(true);
  const [userInformations, setUserInformations] =
    React.useState<UserInformations>(DefaultUserInformations);
  const [IsInvalid] = React.useState<boolean>(false);

  React.useEffect(() => {
    setUserInformations(DefaultUserInformations);
  }, [DefaultUserInformations]);

  React.useEffect(() => {
    if (isFirstRender.current) {
      isFirstRender.current = false;
      return;
    }
    setUserInformations((prevState) => ({
      ...prevState,
      ...DefaultUserInformations,
    }));
  }, [DefaultUserInformations]);

  return {
    isFirstRender,
    userInformations,
    setUserInformations,
    IsInvalid,
  };
}