import { useEffect, useRef } from "react";

interface SearchDialogProps {
  onClose: () => void;
}

export function SearchDialog({ onClose }: SearchDialogProps) {
  const inputRef = useRef<HTMLInputElement>(null);

  useEffect(() => {
    // Focus the input when the dialog opens
    inputRef.current?.focus();

    // Close on Escape key
    const handleKeyDown = (e: KeyboardEvent) => {
      if (e.key === "Escape") {
        onClose();
      }
    };
    window.addEventListener("keydown", handleKeyDown);
    return () => window.removeEventListener("keydown", handleKeyDown);
  }, [onClose]);

  return (
    <div className="search-overlay" onClick={onClose}>
      <div className="search-dialog" onClick={(e) => e.stopPropagation()}>
        <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round" className="search-icon-input">
          <circle cx="11" cy="11" r="8"></circle>
          <line x1="21" y1="21" x2="16.65" y2="16.65"></line>
        </svg>
        <input 
          ref={inputRef}
          type="text" 
          placeholder="Buscar painéis, tabelas..." 
          className="search-input"
        />
        <button className="icon-btn search-close-btn" onClick={onClose} title="Fechar (Esc)">
          ✖
        </button>
      </div>
    </div>
  );
}
