const config = {
  baseApiUrl: "https://localhost:4004",
};

export const dateFormatter = new Intl.DateTimeFormat("en-US", {
  year: "numeric",
  month: "short",
  day: "2-digit",
});

// Optional helper function
export const formatDate = (date: string | Date): string => {
  const d = new Date(date);
  return dateFormatter.format(d);
};

export default config;
