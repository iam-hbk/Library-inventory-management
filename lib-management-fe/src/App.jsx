import { useEffect, useState } from "react";
import { getInventory, getInventoryItem } from "./lib/inventory";
import { getCheckouts } from "./lib/checkout";
import { getCustomer } from "./lib/customer";

export default function App() {
  const [first, setfirst] = useState([]);
  const [second, setsecond] = useState();
  const [third, setthird] = useState([]);

  async function fetchData(id) {
    setfirst(await getInventory());
    setsecond(await getCustomer(id));
    setthird(await getCheckouts())
  }

  useEffect(() => {}, []);

  return (
    <div
      className="text-3xl font-bold bg-base-100 flex w-[100vw] h-[100vh] justify-center
   items-center flex-col gap-4"
    >
      <p>Hello world!</p>
      <button onClick={() => fetchData(3)} className="btn btn-primary">
        Fetch Data
      </button>
      <div>
        {first.map((item, key) => {
          return <div key={key}>{JSON.stringify(item)}</div>;
        })}
      </div>
      <div>{JSON.stringify(second)}</div>
      <div>
        {third.map((item, key) => {
          return <div key={key}>{JSON.stringify(item)}</div>;
        })}
      </div>
    </div>
  );
}
