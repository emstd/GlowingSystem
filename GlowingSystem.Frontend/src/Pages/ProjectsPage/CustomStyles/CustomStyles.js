  const customStyles = (colorMode) => ({
    control: (provided) => ({
      ...provided,
      backgroundColor: colorMode === "dark" ? "#2D3748" : "#fff",
      borderColor: colorMode === "dark" ? "#4A5568" : "#E2E8F0",
      color: colorMode === "dark" ? "#E2E8F0" : "#2D3748",
    }),
    menu: (provided) => ({
      ...provided,
      backgroundColor: colorMode === "dark" ? "#2D3748" : "#fff",
    }),
    multiValue: (provided) => ({
      ...provided,
      backgroundColor: colorMode === "dark" ? "#4A5568" : "#CBD5E0",
    }),
    multiValueLabel: (provided) => ({
      ...provided,
      color: colorMode === "dark" ? "#E2E8F0" : "#2D3748",
    }),
    placeholder: (provided) => ({
      ...provided,
      color: colorMode === "dark" ? "#A0AEC0" : "#718096",
    }),
    option: (provided, state) => ({
      ...provided,
      backgroundColor: state.isFocused 
        ? (colorMode === "dark" ? "#4A5568" : "#E2E8F0")
        : (colorMode === "dark" ? "#2D3748" : "#fff"),    
      color: colorMode === "dark" ? "#E2E8F0" : "#2D3748",
    }),
    input: (provided) => ({
      ...provided,
      color: colorMode === "dark" ? "#E2E8F0" : "#2D3748",
    }),
    singleValue: (provided) => ({
      ...provided,
      color: colorMode === "dark" ? "#E2E8F0" : "#2D3748",
    }),
  });

export default customStyles