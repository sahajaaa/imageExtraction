

namespace InferImages
{
    public class DataExtraction
    {
        public static List<DataObject> Getdata()
        {
            // Replace 'your_excel_sheet.xlsx' with the path to your Excel file
            string filePath = "E:\\InferImages\\InferImages\\Excels\\Mar21.csv";

            // Read all lines from the Excel file
            string[] lines = File.ReadAllLines(filePath);

            // Define a list to store data objects
            List<DataObject> dataObjects = new List<DataObject>();

            // Process each line and extract data
            foreach (string line in lines)
            {
                // Split the line by comma to extract individual values
                string[] values = line.Split(',');

                // Ensure the line has the correct number of values
                if (values.Length == 14)
                {
                    // Parse values and create a data object
                    DataObject dataObject = new DataObject
                    {
                        Timestamp = long.Parse(values[8]), // [xmax, xmin, ymin, ymax] 
                        // [left 3, right 1, top 0, bottom 2] [6, 5, 7, 4]
                        CoordinatesXmin = (float)Math.Round(float.Parse(values[4]), 3),
                        CoordinatesXmax = (float)Math.Round(float.Parse(values[5]), 3),
                        CoordinatesYmin = (float)Math.Round(float.Parse(values[6]), 3),
                        CoordinatesYmax = (float)Math.Round(float.Parse(values[7]), 3),
                        CameraSerial = values[0],
                        Class = int.Parse(values[1]),
                        Confidence = (float)Math.Round(float.Parse(values[3]), 2)
                    };

                    // Add the data object to the list
                    dataObjects.Add(dataObject);
                }
            }

            // Display data stored in the list of objects
            foreach (DataObject dataObject in dataObjects)
            {
                Console.WriteLine($"Timestamp: {dataObject.Timestamp}, CoordinatesYmin: {dataObject.CoordinatesYmin}, CoordinatesXmin: {dataObject.CoordinatesXmin}, CoordinatesYmax: {dataObject.CoordinatesYmax}, CoordinatesXmax: {dataObject.CoordinatesXmax}, CameraSerial: {dataObject.CameraSerial}, Class: {dataObject.Class}, Confidence: {dataObject.Confidence}");
            }

            return dataObjects;
        }
    }
}
