import { ProgressSpinner } from "primereact/progressspinner";
import "../styles/globals.scss";

export default function Loading() {
  return (
    <div className="loadingSection flexRow">
      <ProgressSpinner
        style={{ width: "50px", height: "50px" }}
        strokeWidth="8"
        fill="var(--surface-ground)"
        animationDuration=".5s"
      />
    </div>
  );
}
