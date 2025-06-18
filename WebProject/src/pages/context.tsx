"use client";

import React, { useContext } from "react";
import { createContext } from "react";

const AppContext = createContext<any>(undefined);

export function AppWrapper({ children, }: Readonly<{
  children: React.ReactNode;
}>){

    const [userInformations, setUserInformations] = React.useState({});

    return (
      <AppContext.Provider value={{userInformations, setUserInformations}}>
        {children}
      </AppContext.Provider>
    );

}

export function useAppContext(){
    return useContext(AppContext);
}