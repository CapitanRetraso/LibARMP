﻿using LibARMP.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibARMP
{
    public class ArmpTable
    {
        public ArmpTable()
        {
            Entries = new List<ArmpEntry>();
        }

        /// <summary>
        /// Entry names.
        /// </summary>
        public ArmpTableInfo TableInfo { get; set; }

        /// <summary>
        /// Entry names.
        /// </summary>
        public List<string> RowNames { get; set; }

        /// <summary>
        /// Column names.
        /// </summary>
        public List<string> ColumnNames { get; set; }

        /// <summary>
        /// Text.
        /// </summary>
        public List<string> Text { get; set; }

        /// <summary>
        /// Row validity.
        /// </summary>
        public List<bool> RowValidity { get; set; }

        /// <summary>
        /// Column validity.
        /// </summary>
        public List<bool> ColumnValidity { get; set; }

        /// <summary>
        /// Row indices.
        /// </summary>
        public List<int> RowIndices { get; set; }

        /// <summary>
        /// Column indices.
        /// </summary>
        public List<int> ColumnIndices { get; set; }

        /// <summary>
        /// Column data types.
        /// </summary>
        public List<Type> ColumnDataTypes { get; set; }

        /// <summary>
        /// Column data types (auxiliary).
        /// </summary>
        public List<Type> ColumnDataTypesAux { get; set; }

        /// <summary>
        /// List of entries.
        /// </summary>
        public List<ArmpEntry> Entries { get; set; }




        /// <summary>
        /// Returns all entries in the table.
        /// </summary>
        /// <returns>An ArmpEntry list.</returns>
        public List<ArmpEntry> GetAllEntries ()
        {
            try
            {
                return Entries;
            }
            catch (Exception e)
            {
                throw new EntryNotFoundException("No entries found for this table.");
            }
        }


        /// <summary>
        /// Returns all entries in the table.
        /// </summary>
        /// <returns>An ArmpEntry list.</returns>
        public ArmpEntry GetEntry (int id)
        {
            try
            {
                return Entries[id];
            }
            catch (Exception e) 
            {
                throw new EntryNotFoundException("No entry with ID '"+id+"'.");
            }
        }


        /// <summary>
        /// Searches all entries for matching names.
        /// </summary>
        /// <param name="name">The name to search for.</param>
        /// <returns>An ArmpEntry list.</returns>
        public List<ArmpEntry> SearchByName (string name)
        {
            List<ArmpEntry> returnList = new List<ArmpEntry>();
            foreach(ArmpEntry entry in Entries)
            {
                if (entry.Name.Contains(name)) returnList.Add(entry);
            }
            return returnList;
        }


        /// <summary>
        /// Searches all entries for matching vales in the specified column.
        /// </summary>
        /// <param name="column">The column containing the value to find.</param>
        /// <param name="value">The value to find.</param>
        /// <returns>An ArmpEntry list.</returns>
        public List<ArmpEntry> SearchByValue (string column, object value)
        {
            if (!ColumnNames.Contains(column)) throw new ColumnNotFoundException("The column '"+column+"' does not exist in this table.");
            int columnIndex = ColumnNames.IndexOf(column);
            value = Convert.ChangeType(value, ColumnDataTypesAux[columnIndex]);

            List<ArmpEntry> returnList = new List<ArmpEntry>();
            foreach (ArmpEntry entry in Entries)
            {
                if (value.Equals(entry.Data[column]))
                {
                    returnList.Add(entry);
                }
            }
            return returnList;
        }


        /// <summary>
        /// Adds an entry to the end of the table.
        /// </summary>
        /// <param name="entry">The entry to add.</param>
        public void AddEntry (ArmpEntry entry)
        {
            int id = Entries.Count + 1;
            entry.ID = id;
            entry.Index = id;
            Entries.Add(entry);
        }


        /// <summary>
        /// Inserts an entry in a specific spot in the table. NOT IMPLEMENTED
        /// </summary>
        /// <param name="entry">The entry to add.</param>
        /// <param name="id">Place in which the entry will be inserted.</param>
        public void AddEntry (ArmpEntry entry, int id)
        {
            //TODO
            throw new NotImplementedException();
        }


        /// <summary>
        /// Returns a dummy entry for the specified table.
        /// </summary>
        public ArmpEntry GenerateTemplateArmpEntry()
        {
            //Entry 0 is always empty, dirty approach is to make a copy.
            //FIXME This wont work for empty armps (not a realistic case but an issue regardless) and subtables may have weird results.
            ArmpEntry template;
            template = GetEntry(0);
            return template;
        }


        /// <summary>
        /// Sets the value of a specified column in the specified entry.
        /// </summary>
        /// <param name="id">The entry to modify.</param>
        /// <param name="column">The column name.</param>
        /// <param name="value">The value to write.</param>
        public void SetValue (int id, string column, object value)
        {
            int columnIndex = ColumnNames.IndexOf(column);

            if (columnIndex != -1)
            {
                if (value.GetType() == ColumnDataTypesAux[columnIndex])
                {
                    ArmpEntry entry = GetEntry(id);
                    entry.SetValueFromColumn(column, value);
                }
                else
                {
                    //TODO
                    throw new Exception("Type mismatch. Expected '"+ ColumnDataTypesAux[columnIndex] + "' and got '"+value.GetType()+"'.");
                }
            }
            else
            {
                throw new ColumnNotFoundException("The column '" + column + "' does not exist.");
            }

            

        }
    }
}
